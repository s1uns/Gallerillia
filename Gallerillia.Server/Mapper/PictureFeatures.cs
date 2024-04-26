using AutoMapper;
using Core.Models;
using Infrustructure.Dto.Picture;


namespace Gallerillia.Server.Mapper
{
    public class PictureFeatures : Profile
    {
        public PictureFeatures()
        {
            CreateMap<CreatePictureDto, Picture>();

        }
    }
}
