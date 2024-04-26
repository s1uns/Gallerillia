using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Album
{
    public record AlbumDto
    (
        Guid Id,
        string ImgUrl,
        string Title,
        string Author,
        string AuthorId
    );
}
