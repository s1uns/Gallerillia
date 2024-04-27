using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Errors.ServiceErrors
{
    public static class IdentityServiceErrors
    {
        public static readonly Error InvalidUserEmail = new Error("Invalid User Email Error", "User's email is invalid");
        public static readonly Error WrongOldPasswordError = new Error("Wrong Old Password Error", "The old password is wrong");
        public static readonly Error NotAdministratorError = new Error("NotAdministratorError", "You must be an administrator to be able to do this.");

        public static Error CreateAccountError(string errorMessage) => new Error("Create Account Error", errorMessage);
        public static Error SignInError(string errorMessage) => new Error("Sign In Error", errorMessage);
    }
}