using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Picture
{
    public record CreatePictureDto
    (
        Guid AlbumId,
        string ImgUrl
    );
}
