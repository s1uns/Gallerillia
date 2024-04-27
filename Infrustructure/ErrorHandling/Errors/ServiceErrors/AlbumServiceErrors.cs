using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Errors.ServiceErrors
{
    public class AlbumServiceErrors
    {
        public static Error CreateAlbumError = new Error("Create Album Error", "Couldn't create this album.");
        public static Error GetAlbumsListError = new Error("Get Album List Error", "Couldn't get the list of available album.");
        public static Error GetAlbumByIdError = new Error("Get Album By Id Error", "Couldn't get information about this album.");
        public static Error UpdateAlbumError = new Error("Update Album Error", "Couldn't update information about this album.");
        public static Error DeleteAlbumError = new Error("Delete Album Error", "Couldn't delete this album.");
        public static Error NotYourAlbumError = new Error("Not Your Album Error", "This is not your album!");

    }
}
