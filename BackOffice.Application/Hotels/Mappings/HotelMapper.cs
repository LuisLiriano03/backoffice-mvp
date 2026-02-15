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

        //public static Card ToEntity(this CreateCard dto)
        //{
        //    if (dto == null) return null;

        //    return new Card
        //    {
        //        CardNumber = dto.CardNumber,
        //        ExpirationDate = dto.ExpirationDate,
        //        CardholderName = dto.CardholderName,
        //        Cvv = dto.Cvv,
        //        IsActive = true,
        //        IsDeleted = false,
        //        CreatedDate = DateTime.Now,
        //        UpdatedDate = DateTime.Now
        //    };
        //}

        //public static void ApplyUpdate(this Card entity, UpdateCard dto)
        //{
        //    if (entity == null || dto == null) return;

        //    entity.CardId = dto.Id;
        //    entity.CardNumber = dto.CardNumber;
        //    entity.ExpirationDate = dto.ExpirationDate;
        //    entity.CardholderName = dto.CardholderName;
        //    entity.Cvv = dto.Cvv;
        //    entity.IsActive = dto.IsActive == (int)ActiveFlag.Active;
        //    entity.UpdatedDate = DateTime.Now;
        //}

    }

}
