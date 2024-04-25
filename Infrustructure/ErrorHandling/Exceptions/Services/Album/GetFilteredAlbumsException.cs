using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Exceptions.Services.Album
{
    public class GetFilteredAlbumsException : Exception
    {
        public GetFilteredAlbumsException() { }
        public GetFilteredAlbumsException(string message) : base(message) { }
        public GetFilteredAlbumsException(string message, Exception inner) : base(message, inner) { }
    }
}
