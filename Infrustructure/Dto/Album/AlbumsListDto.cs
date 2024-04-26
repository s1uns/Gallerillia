using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Album
{
    public record AlbumsListDto
    (
        IList<AlbumDto> Albums, 
        int TotalPages
    );

}
