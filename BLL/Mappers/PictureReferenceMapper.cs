using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class PictureReferenceMapper
    {
        public static PictureReferenceDto MapToDto(PictureReference pictureReference)
        {
            return new PictureReferenceDto
            {
                IdPictureReference = pictureReference.IdPictureReference,
                Path = pictureReference.Path,
                ModificationDate = pictureReference.ModificationDate,
                PlantReferenceCollection = pictureReference.PlantReferenceCollection.Select(PlantReferenceMapper.MapToDto).ToList()
            };
        }

        public static PictureReference MapToEntity(PictureReferenceDto pictureReferenceDto)
        {
            return new PictureReference
            {
                IdPictureReference = pictureReferenceDto.IdPictureReference,
                Path = pictureReferenceDto.Path,
                ModificationDate = pictureReferenceDto.ModificationDate,
                PlantReferenceCollection = pictureReferenceDto.PlantReferenceCollection.Select(PlantReferenceMapper.MapToEntity).ToList()
            };
        }
    }
}
