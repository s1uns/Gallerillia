using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Exceptions.Services.Account
{
    public class IdentityEmailNotFoundException : Exception
    {
        public IdentityEmailNotFoundException() { }
        public IdentityEmailNotFoundException(string message) : base(message) { }
        public IdentityEmailNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
