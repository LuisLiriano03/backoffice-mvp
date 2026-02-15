using BackOffice.Application.Hotels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Interfaces
{
    public interface IHotelService
    {
        Task<GetHotels> GetHotelByIdAsync(int id);
        Task<List<GetHotels>> GetAllHotelAsync();
        //Task<GetCards> Create(CreateCard model);
        //Task<bool> UpdateAsync(UpdateCard destination);
        //Task<bool> SoftDeleteAsync(int cardId);
    }
}
