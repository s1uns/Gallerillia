using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Picture
{
    public record PictureDto
    (
        Guid Id,
        string ImgUrl,
        int UpVotesCount,
        int DownVotesCount,
        string UsersVote
    );
   
}
