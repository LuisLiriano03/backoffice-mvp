using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Exceptions
{
    public class HotelNotFoundException : Exception
    {
        public override string Message { get; }

        public HotelNotFoundException() : base()
        {
            Message = "Hotel ID not found";
        }
    }


}
