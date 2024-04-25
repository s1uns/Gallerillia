using AutoMapper;
using Core.Models;
using Infrustructure.Dto.Album;


namespace Gallerillia.Server.Mapper
{
    public class AlbumFeatures : Profile
    {
        public AlbumFeatures()
        {
            CreateMap<Album, AlbumDto>()
                .ForCtorParam(nameof(AlbumDto.Author), otp => otp.MapFrom(src => src.Author.Email.Substring(0, src.Author.Email.IndexOf('@'))));
            CreateMap<CreateAlbumDto, Album>();
            CreateMap<UpdateAlbumDto, Album>();

        }
    }
}
