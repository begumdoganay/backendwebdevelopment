using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
