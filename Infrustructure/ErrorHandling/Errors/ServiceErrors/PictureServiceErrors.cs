using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Errors.ServiceErrors
{
    public class PictureServiceErrors
    {
        public static Error CreatePictureError = new Error("Create Picture Error", "Couldn't create this picture.");
        public static Error GetPicturesListError = new Error("Get Picture List Error", "Couldn't get the list of available picture.");
        public static Error GetPictureByIdError = new Error("Get Picture By Id Error", "Couldn't get information about this picture.");
        public static Error DeletePictureError = new Error("Delete Picture Error", "Couldn't delete this picture.");
        public static Error NotYourPictureError = new Error("Not Your Picture Error", "This is not your picture!");
    }
}
