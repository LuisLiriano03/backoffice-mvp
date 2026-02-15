using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Exceptions
{
    public class HotelNotUpdateFailedException : Exception
    {
        public override string Message { get; }

        public HotelNotUpdateFailedException() : base()
        {
            Message = "The hotel could not be updated";
        }

    }
}
