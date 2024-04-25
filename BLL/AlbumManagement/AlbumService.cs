using AutoMapper;
using Core;
using Core.Models;
using DAL;
using Infrustructure.Dto.Album;
using Infrustructure.ErrorHandling.Errors.Base;
using Infrustructure.ErrorHandling.Errors.ServiceErrors;
using Infrustructure.ErrorHandling.Exceptions.Services.Album;
using Infrustructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace BLL.AlbumsManagement
{
    public class AlbumService : IAlbumService
    {
        private readonly ILogger<AlbumService> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public AlbumService(ILogger<AlbumService> logger, IMapper mapper, ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public async Task<Result<string, Error>> CreateAlbumAsync(CreateAlbumDto createAlbumDto)
        {
            try
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var user = await _context.OrdinaryUsers.Where(u => u.Id == userId).Include(u => u.Albums).FirstOrDefaultAsync();
                var album = _mapper.Map<Album>(createAlbumDto);
                await _context.Albums.AddAsync(album);
                user.Albums.Add(album);
                await _context.SaveChangesAsync();
                return "Created the album successfully!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.CreateAlbumAsync ERROR: {ex.Message}");
                return AlbumServiceErrors.CreateAlbumError;
            }
        }

        public async Task<Result<string, Error>> DeleteAlbumAsync(Guid albumId)
        {
            try
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var userHasRoles = _contextAccessor.TryGetUserRole(out string userRole);

                if (!userHasRoles)
                {
                    return UserErrors.InvalidUserId;
                }

                var album = await _context.Albums.FirstOrDefaultAsync(bE => bE.Id == albumId);

                if (album is null)
                {
                    return AlbumServiceErrors.GetAlbumByIdError;
                }

                if(userId != album.AuthorId && userRole != "Administrator")
                {
                    return AlbumServiceErrors.NotYourAlbumError;
                }

                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
                return "Deleted the album successfully!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.DeleteAlbumAsync ERROR: {ex.Message}");
                return AlbumServiceErrors.DeleteAlbumError;
            }
        }

        public async Task<Result<AlbumsListDto, Error>> GetAllAlbumsAsync(int pageNumber)
        {
            try
            {
                var result = await GetFilteredAlbums(_context.Albums.Include(a => a.Author), pageNumber);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetAllAlbumsAsync ERROR: {ex.Message}");
                return AlbumServiceErrors.GetAlbumsListError;
            }
        }

        public async Task<Result<AlbumsListDto, Error>> GetOwnAlbumsAsync(int pageNumber)
        {
            try
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var result = await GetFilteredAlbums(_context.Albums.Where(a => a.AuthorId == userId), pageNumber);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetAllAlbumsAsync ERROR: {ex.Message}");
                return AlbumServiceErrors.GetAlbumsListError;
            }
        }

        public async Task<Result<string, Error>> UpdateAlbumAsync(UpdateAlbumDto updateAlbumDto)
        {
            try
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var userHasRoles = _contextAccessor.TryGetUserRole(out string userRole);

                if (!userHasRoles)
                {
                    return UserErrors.InvalidUserId;
                }

                var album = await _context.Albums.FirstOrDefaultAsync(bE => bE.Id == updateAlbumDto.Id);

                if (album is null)
                {
                    return AlbumServiceErrors.GetAlbumByIdError;
                }

                if (userId != album.AuthorId && userRole != "Administrator")
                {
                    return AlbumServiceErrors.NotYourAlbumError;
                }

                _mapper.Map(updateAlbumDto, album);
                await _context.SaveChangesAsync();
                return "Updated the album successfully!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.UpdateAlbumAsync ERROR: {ex.Message}");
                return AlbumServiceErrors.UpdateAlbumError;
            }
        }


        private async Task<Result<AlbumsListDto, Error>> GetFilteredAlbums(IQueryable<Album> query,int pageNumber)
        {
            try
            {
                var albums = _mapper.Map<IList<AlbumDto>>(await query.Include(a => a.Author).Skip((pageNumber - 1) * 5).Take(5).ToListAsync());
                var totalPages = (query.Count() + 5 - 1) / 5;

                var result = new AlbumsListDto(albums, totalPages);

                return result;

            }
            catch(Exception e)
            {
                throw new GetFilteredAlbumsException(e.Message);
            }
        }
    }
}
