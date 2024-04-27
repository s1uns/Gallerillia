using AutoMapper;
using BLL.AlbumsManagement;
using Core;
using Core.Models;
using DAL;
using Infrustructure.Dto.Album;
using Infrustructure.Dto.Picture;
using Infrustructure.ErrorHandling.Errors.Base;
using Infrustructure.ErrorHandling.Errors.ServiceErrors;
using Infrustructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL.PictureManagement
{
    public class PictureService : IPictureService
    {
        private readonly ILogger<PictureService> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public PictureService(ILogger<PictureService> logger, IMapper mapper, ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<Result<string, Error>> DeletePictureAsync(Guid pictureId)
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

                var picture = await _context.Pictures.FirstOrDefaultAsync(p => p.Id == pictureId);

                if (picture is null)
                {
                    return PictureServiceErrors.GetPictureByIdError;
                }

                var album = await _context.Albums.Where(a => a.Id == picture.AlbumId).Include(a => a.Pictures).FirstOrDefaultAsync();


                if (userId != picture.Album.AuthorId && userRole != "Administrator")
                {
                    return PictureServiceErrors.NotYourPictureError;
                }

                if (album.ImgUrl == picture.ImgUrl)
                {
                    if (album.Pictures.Count() < 2)
                    {
                        album.ImgUrl = "";
                    }
                    else
                    {
                        album.ImgUrl = _context.Pictures.FirstOrDefault(p => p.AlbumId == album.Id && p.Id != pictureId).ImgUrl;
                    }

                }

                _context.Pictures.Remove(picture);

                await _context.SaveChangesAsync();
                return "Deleted the picture successfully!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.DeletePictureAsync ERROR: {ex.Message}");
                return PictureServiceErrors.DeletePictureError;
            }
        }

        public async Task<Result<PicturesListDto, Error>> GetPicturesAsync(Guid albumId, int pageNumber)
        {
            try
            {

                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                var votesCountQuery = _context.Votes.AsQueryable();
                var userVoteQuery = _context.Votes.Where(v => v.UserId == userId);

                var query = _context.Pictures.Where(p => p.AlbumId == albumId);
                var count = await query.CountAsync();

                var totalPages = (count + 5 - 1) / 5;
                var album = await _context.Albums.FirstOrDefaultAsync(a => a.Id == albumId);

                if (album is null)
                {
                    return AlbumServiceErrors.GetAlbumByIdError;
                }
                var pictures = await query.Include(a => a.Votes).Skip(pageNumber * 5).Take(5).ToListAsync();
                var result = new PicturesListDto(new List<PictureDto> { }, totalPages, album.AuthorId);

                await pictures.ForEachAsync(async (p) =>
                {
                    var upvotesCount = await votesCountQuery.Where(v => v.PictureId == p.Id && v.IsPositive).CountAsync();
                    var downvotesCount = await votesCountQuery.Where(v => v.PictureId == p.Id && !v.IsPositive).CountAsync();
                    var userVoteStatus = await userVoteQuery.AnyAsync(v => v.PictureId == p.Id && v.IsPositive)
                        ? nameof(VoteStatus.UPVOTED)
                        : await userVoteQuery.AnyAsync(v => v.PictureId == p.Id && !v.IsPositive)
                            ? nameof(VoteStatus.DOWNVOTED)
                            : nameof(VoteStatus.UNVOTED);

                    result.Pictures.Add(new PictureDto(p.Id, p.ImgUrl, upvotesCount, downvotesCount, userVoteStatus));
                });


                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetPicturesAsync ERROR: {ex.Message}");
                return PictureServiceErrors.GetPicturesListError;
            }
        }

        public async Task<Result<string, Error>> UploadPictureAsync(CreatePictureDto createPictureDto)
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

                var album = await _context.Albums.Where(a => a.Id == createPictureDto.AlbumId).Include(a => a.Pictures).FirstOrDefaultAsync();

                if (album is null)
                {
                    return AlbumServiceErrors.GetAlbumByIdError;
                }

                if (userId != album.AuthorId && userRole != "Administrator")
                {
                    return AlbumServiceErrors.NotYourAlbumError;

                }

                var picture = _mapper.Map<Picture>(createPictureDto);


                if (!album.Pictures.Any())
                {
                    album.ImgUrl = picture.ImgUrl;
                }

                await _context.Pictures.AddAsync(picture);
                album.Pictures.Add(picture);
                await _context.SaveChangesAsync();
                return "Created the picture successfully!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.UploadPictureAsync ERROR: {ex.Message}");
                return PictureServiceErrors.CreatePictureError;
            }
        }

        public async Task<Result<string, Error>> VotePictureAsync(Guid pictureId, string voteStatus)
        {
            try
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var picture = await _context.Pictures.Include(p => p.Votes).Include(p => p.Album).FirstOrDefaultAsync(p => p.Id == pictureId);

                if (picture is null)
                {
                    return PictureServiceErrors.GetPictureByIdError;
                }

                if (picture.Album.AuthorId == userId)
                {
                    return PictureServiceErrors.CannotVoteYourPictureError;
                }

                var vote = await _context.Votes.FirstOrDefaultAsync(v => v.UserId == userId && v.PictureId == pictureId);

                if (vote is null)
                {

                    switch (voteStatus)
                    {
                        case "UPVOTED":
                        case "DOWNVOTED":
                            vote = new Vote
                            {
                                UserId = userId,
                                PictureId = pictureId,
                                IsPositive = voteStatus == "UPVOTED"
                            };
                            await _context.Votes.AddAsync(vote);
                            picture.Votes.Add(vote);
                            break;
                        case "UNVOTED":
                            return PictureServiceErrors.RestractVoteError;

                        default:
                            return PictureServiceErrors.WrongVoteInformation;
                    }
                }
                else
                {

                    switch (voteStatus)
                    {
                        case "UPVOTED":
                        case "DOWNVOTED":
                            vote.IsPositive = voteStatus == "UPVOTED";
                            break;

                        case "UNVOTED":
                            _context.Votes.Remove(vote);
                            break;

                        default:
                            return PictureServiceErrors.WrongVoteInformation;
                    }
                }

                await _context.SaveChangesAsync();
                return "Voted this picture successfully!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.VotePictureAsync ERROR: {ex.Message}");
                return PictureServiceErrors.VotePictureError;
            }
        }
    }
}
