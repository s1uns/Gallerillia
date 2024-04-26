using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Errors.ServiceErrors
{
    public static class UserErrors
    {
        public static Error InvalidUserId = new Error("Invalid User Id Error", "User's id is invalid");
    }
}
