using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Exceptions.Services.Account
{
    public class IdentityRoleNotFoundException : Exception
    {
        public IdentityRoleNotFoundException() { }
        public IdentityRoleNotFoundException(string message) : base(message) { }
        public IdentityRoleNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
