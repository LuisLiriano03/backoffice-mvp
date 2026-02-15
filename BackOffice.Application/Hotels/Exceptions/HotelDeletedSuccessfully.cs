using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Exceptions
{
    public class HotelDeletedSuccessfully : Exception
    {
        public override string Message { get; }

        public HotelDeletedSuccessfully() : base()
        {
            Message = "The card was deleted.";
        }
    }
}
