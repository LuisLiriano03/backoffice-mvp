using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Exceptions
{
    public class HotelAlreadyExistsException : Exception
    {
        public override string Message { get; }

        public HotelAlreadyExistsException(string errorMessage) : base(errorMessage)
        {
            Message = "The following fields already exist for another hotel: " + errorMessage;
        }
    }
}
