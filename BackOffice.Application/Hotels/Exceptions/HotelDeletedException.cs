using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Exceptions
{
    public class HotelDeletedException : Exception
    {
        public override string Message { get; }

        public HotelDeletedException() : base()
        {
            Message = "The following fields already exist for another hotel ";
        }

    }
}
