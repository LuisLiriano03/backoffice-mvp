using BackOffice.API.Utility;
using BackOffice.Application.Hotels.DTOs;
using BackOffice.Application.Hotels.Interfaces;
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

                response.message = "The hotel was successful";
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
                response.message = "The hotel was successful";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> create([FromBody] CreateHotel createHotel)
        {
            var response = new Response<GetHotels>();

            try
            {
                response.status = true;
                response.value = await _hotelService.Create(createHotel);
                response.message = "Hotel was successful";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }


        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> EditCard([FromBody] UpdateHotel updateHotel)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _hotelService.UpdateAsync(updateHotel);
                response.message = "Hotel information updated successfully";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.value = await _hotelService.SoftDeleteAsync(id);
                response.status = true;
                response.message = "Hotel deleted successfully";
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
