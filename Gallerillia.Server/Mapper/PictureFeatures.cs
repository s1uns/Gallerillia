using AutoMapper;
using Core.Models;
using Infrustructure.Dto.Picture;


namespace Gallerillia.Server.Mapper
{
    public class PictureFeatures : Profile
    {
        public PictureFeatures()
        {
/*            CreateMap<Picture, PictureDto>()
                .ForCtorParam(nameof(PictureDto.AuthorId), otp => otp.MapFrom(src => src.Album.AuthorId));*/
            CreateMap<CreatePictureDto, Picture>();

        }
    }
}
