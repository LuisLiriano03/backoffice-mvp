using BackOffice.Application.Hotels.DTOs;
using BackOffice.Domain.Entities;
using BackOffice.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Mappings
{
    public static class CardMapper
    {
        public static GetHotels ToDto(this Hotel hotel)
        {
            if (hotel == null) return null;

            return new GetHotels
            {
                HotelId = hotel.HotelId,
                HotelName = hotel.HotelName,
                City = hotel.City,
                Country = hotel.Country,
                IsActive = hotel.IsActive == true ? (int)ActiveFlag.Active : (int)ActiveFlag.Inactive,
                IsDeleted = hotel.IsDeleted == true ? (int)DeleteFlag.Deleted : (int)DeleteFlag.NotDeleted

            };

        }

        public static Hotel ToEntity(this CreateHotel dto)
        {
            if (dto == null) return null;

            return new Hotel
            {
                HotelName = dto.HotelName,
                City = dto.City,
                Country = dto.Country,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
        }

        public static void ApplyUpdate(this Hotel entity, UpdateHotel dto)
        {
            if (entity == null || dto == null) return;

            entity.HotelId = dto.HotelId;
            entity.HotelName = dto.HotelName;
            entity.City = dto.City;
            entity.Country = dto.Country;
            entity.IsActive = dto.IsActive == (int)ActiveFlag.Active;
            entity.UpdatedDate = DateTime.Now;
        }

    }

}
