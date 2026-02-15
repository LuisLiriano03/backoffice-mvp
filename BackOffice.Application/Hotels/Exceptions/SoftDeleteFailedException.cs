using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Application.Hotels.Exceptions
{
    public class SoftDeleteFailedException : Exception
    {
        public override string Message { get; }
        public SoftDeleteFailedException() : base()
        {
            Message = "Was not deleted";
        }

    }
}
