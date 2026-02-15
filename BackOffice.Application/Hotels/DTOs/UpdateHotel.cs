using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.DTOs
{
    public class UpdateHotel
    {
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int IsActive { get; set; }
    }
}
