using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Exceptions.Services.Account
{
    public class SignInExceiption : Exception
    {
        public SignInExceiption() { }
        public SignInExceiption(string message) : base(message) { }
        public SignInExceiption(string message, Exception inner) : base(message, inner) { }
    }
}