using Core;
using Infrustructure.Dto.Picture;
using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PictureManagement
{
    public interface IPictureService
    {
        public Task<Result<string, Error>> UploadPictureAsync(CreatePictureDto createPictureDto);
        public Task<Result<PicturesListDto, Error>> GetPicturesAsync(Guid albumId, int pageNumber);
        public Task<Result<string, Error>> DeletePictureAsync(Guid pictureId);

    }
}
