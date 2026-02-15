using BackOffice.Application.Hotels.DTOs;
using BackOffice.Application.Hotels.Exceptions;
using BackOffice.Application.Hotels.Interfaces;
using BackOffice.Application.Hotels.Mappings;
using BackOffice.Domain.Entities;
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

        
    }
}
