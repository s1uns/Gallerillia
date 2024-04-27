using Core;
using Infrustructure.Dto.Album;
using Infrustructure.ErrorHandling.Errors.Base;


namespace BLL.AlbumsManagement
{
    public interface IAlbumService
    {
        public Task<Result<AlbumsListDto, Error>> GetAllAlbumsAsync(int pageNumber);
        public Task<Result<AlbumsListDto, Error>> GetOwnAlbumsAsync(int pageNumber);
        public Task<Result<string, Error>> CreateAlbumAsync(CreateAlbumDto createAlbumDto);
        public Task<Result<string, Error>> UpdateAlbumAsync(UpdateAlbumDto updateAlbumDto);
        public Task<Result<string, Error>> DeleteAlbumAsync(Guid albumId);
    }
}
