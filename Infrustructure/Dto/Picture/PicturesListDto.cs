namespace Infrustructure.Dto.Picture
{
    public record PicturesListDto
    (
      IList<PictureDto> Pictures, 
      int TotalPages,
      Guid AuthorId
    );
}
