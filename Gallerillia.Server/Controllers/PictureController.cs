using BLL.PictureManagement;
using Infrustructure.Dto.Picture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gallerillia.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {

        private readonly IPictureService _pictureService;
        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        /// <summary>
        /// Get's the list of pictures in the album.
        /// </summary>
        /// <param name="albumId">The id of the album we get the pictures from.</param>
        /// <param name="page">The current page of the albums list.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetPictures([FromQuery] Guid albumId, int page = 0)
        {
            var result = await _pictureService.GetPicturesAsync(albumId, page);

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Uploads a new picture.
        /// </summary>
        /// <param name="createPictureDto">The dto to upload a picture.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePicture([FromBody] CreatePictureDto createPictureDto)
        {
            var result = await _pictureService.UploadPictureAsync(createPictureDto);

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Deletes an existing picture.
        /// </summary>
        /// <param name="id">The id of the picture which should be deleted.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePicture(Guid id)
        {
            var result = await _pictureService.DeletePictureAsync(id);

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Votes an existing picture.
        /// </summary>
        /// <param name="pictureId">The id of the picture which should be voted.</param>
        /// <param name="voteStatus">The info about given vote.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("vote")]
        [Authorize]
        public async Task<IActionResult> VotePicture([FromQuery] Guid pictureId, string voteStatus)
        {
            var result = await _pictureService.VotePictureAsync(pictureId, voteStatus);

            return this.CreateResponse(result);
        }
    }
}
