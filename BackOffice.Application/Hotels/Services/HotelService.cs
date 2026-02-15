using BackOffice.Application.Hotels.DTOs;
using BackOffice.Application.Hotels.Exceptions;
using BackOffice.Application.Hotels.Interfaces;
using BackOffice.Application.Hotels.Mappings;
using BackOffice.Application.Hotels.Validators;
using BackOffice.Domain.Entities;
using BackOffice.Domain.Enums;
using BackOffice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Services
{
    public class HotelService : IHotelService
    {
        private readonly IGenericRepository<Hotel> _hotelRepository;

        public HotelService(IGenericRepository<Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<GetHotels> GetHotelByIdAsync(int id)
        {
            try
            {
                var entity = await _hotelRepository.GetByIdAsync(id)
                            ?? throw new HotelNotFoundException();

                if (entity.IsDeleted == true)
                    throw new HotelDeletedSuccessfully();

                return entity.ToDto();
            }
            catch
            {
                throw;
            }

        }
        public async Task<List<GetHotels>> GetAllHotelAsync()
        {
            try
            {
                var destinations = await _hotelRepository.VerifyDataExistenceAsync(
                    u => u.IsDeleted == false || u.IsDeleted == null);

                var result = destinations.Select(d => d.ToDto()).ToList();

                return result;
            }
            catch
            {
                throw new GetHotelFailedException();
            }

        }

        public async Task<GetHotels> Create(CreateHotel createHotel)
        {
            ValidateModel(createHotel);

            var entity = createHotel.ToEntity();

            await CheckIfExists(entity);

            var created = await CreateAsync(entity);

            await VerifyCreation(created);

            return created.ToDto();
        }

        private void ValidateModel(CreateHotel createHotel)
        {
            var validator = new CreateHotelValidator();
            var validation = validator.Validate(createHotel);

            if (!validation.IsValid)
            {
                var errors = string.Join(", ", validation.Errors.Select(e => e.ErrorMessage));
                throw new TaskCanceledException($"Validation failed: {errors}");
            }

        }

        private async Task CheckIfExists(Hotel entity)
        {
            var exists = await _hotelRepository.VerifyDataExistenceAsync(
                hotel => hotel.HotelName == entity.HotelName 
            );

            if (exists.Any())
                throw new HotelAlreadyExistsException(
                    "A hotel with one or more identical fields already exists. All fields must be unique."
                );
        }

        private async Task<Hotel> CreateAsync(Hotel entity)
        {
            return await _hotelRepository.CreateAsync(entity);
        }

        private async Task VerifyCreation(Hotel entity)
        {
            if (entity.HotelId <= (int)HotelCreationOption.DoNotCreate)
                throw new HotelDestinationFailedException();
        }

        public async Task<bool> UpdateAsync(UpdateHotel updateHotel)
        {
            ValidateUpdateModel(updateHotel);

            var entity = await GetEntityById(updateHotel.HotelId);

            await CheckIfExistsForUpdate(updateHotel.HotelId, updateHotel);

            ApplyChanges(entity, updateHotel);

            return await SaveChangesAsync(entity);
        }

        private void ValidateUpdateModel(UpdateHotel updateHotel)
        {
            var validator = new UpdateHotelValidator();
            var validation = validator.Validate(updateHotel);

            if (!validation.IsValid)
            {
                var errors = string.Join(", ", validation.Errors.Select(e => e.ErrorMessage));
                throw new TaskCanceledException($"Validation failed: {errors}");
            }
        }

        private async Task<Hotel> GetEntityById(int id)
        {
            var entity = (await _hotelRepository.VerifyDataExistenceAsync(c => c.HotelId == id))
                .FirstOrDefault()
                ?? throw new HotelNotFoundException();

            if ((bool)entity.IsDeleted)
                throw new HotelDeletedException();

            return entity;
        }

        private async Task CheckIfExistsForUpdate(int id, UpdateHotel updateHotel)
        {
            var exists = await _hotelRepository.VerifyDataExistenceAsync(
                hotel => (hotel.HotelName == updateHotel.HotelName
                || hotel.City == updateHotel.City 
                || hotel.Country == updateHotel.Country) && updateHotel.HotelId != id
            );

            if (exists.Any())
                throw new HotelAlreadyExistsException(
                    "A hotel with one or more identical fields already exists. All fields must be unique."
                );
        }

        private void ApplyChanges(Hotel entity, UpdateHotel updateHotel)
        {
            entity.ApplyUpdate(updateHotel);
            entity.UpdatedDate = DateTime.UtcNow;
        }

        private async Task<bool> SaveChangesAsync(Hotel entity)
        {
            var updated = await _hotelRepository.UpdateAsync(entity);

            if (!updated)
                throw new HotelNotUpdateFailedException();

            return updated;
        }

        public async Task<bool> SoftDeleteAsync(int hotelId)
        {
            var hotel = await _hotelRepository.GetByIdAsync(hotelId)
                ?? throw new HotelNotFoundException();

            return await _hotelRepository.SoftDeleteAsync(hotel)
                ? true
                : throw new SoftDeleteFailedException();
        }

    }

}
