using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Exceptions
{
    public class HotelDestinationFailedException : Exception
    {
        public override string Message { get; }

        public HotelDestinationFailedException() : base()
        {
            Message = "Failed to create a new hotel";
        }
    }
}
