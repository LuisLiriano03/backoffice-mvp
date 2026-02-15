using BackOffice.API.Utility;
using BackOffice.Application.Hotels.DTOs;
using BackOffice.Application.Hotels.Interfaces;
using BackOffice.Domain.Entities;
using BackOffice.Domain.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IActionResult> GetCardById(int id)
        {
            var response = new Response<GetHotels>();

            try
            {
                response.value = await _hotelService.GetHotelByIdAsync(id);

                response.status = response.value != null;

                response.message = "Successful Hotel";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllHotel()
        {
            var response = new Response<List<GetHotels>>();

            try
            {
                response.status = true;
                response.value = await _hotelService.GetAllHotelAsync();
                response.message = "Successful Hotels";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }


    }
}
