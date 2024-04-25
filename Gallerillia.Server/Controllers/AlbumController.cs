using BLL.AlbumsManagement;
using Infrustructure.Dto.Album;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gallerillia.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        /// <summary>
        /// Returns the list of all albums.
        /// </summary>
        /// <param name="page">The current page of the albums list.</param>
        /// <remarks>
        /// If the operation is successful, it will return an AlbumsListDto.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAlbums([FromQuery] int page = 1)
        {
            var result = await _albumService.GetAllAlbumsAsync(page);

            return this.CreateResponse(result);
        }


        /// <summary>
        /// Returns the list of user's albums.
        /// </summary>
        /// <param name="page">The current page of the albums list.</param>
        /// <remarks>
        /// If the operation is successful, it will return an AlbumsListDto.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("my-albums")]
        [Authorize]
        public async Task<IActionResult> GetMyAlbums([FromQuery] int page = 1)
        {
            var result = await _albumService.GetAllAlbumsAsync(page);

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Creates a new album.
        /// </summary>
        /// <param name="createAlbumDto">The dto to create an album.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateAlbum([FromBody] CreateAlbumDto createAlbumDto)
        {
            var result = await _albumService.CreateAlbumAsync(createAlbumDto);

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Updated an existing album.
        /// </summary>
        /// <param name="updateAlbumDto">The dto to update an album.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> UpdateAlbum([FromBody] UpdateAlbumDto updateAlbumDto)
        {
            var result = await _albumService.UpdateAlbumAsync(updateAlbumDto);

            return this.CreateResponse(result);
        }


        /// <summary>
        /// Deletes an existing album.
        /// </summary>
        /// <param name="id">The id of the album which should be deleted.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAlbum(Guid id)
        {
            var result = await _albumService.DeleteAlbumAsync(id);

            return this.CreateResponse(result);
        }

    }
}
