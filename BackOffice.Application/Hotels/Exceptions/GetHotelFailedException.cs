using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Exceptions
{
    public class GetHotelFailedException : Exception
    {
        public override string Message { get; }

        public GetHotelFailedException() : base()
        {
            Message = "No Hotel found;";
        }

    }
}
