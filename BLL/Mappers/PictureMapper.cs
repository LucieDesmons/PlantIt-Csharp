using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class PictureMapper
    {
        public static PictureDto MapToDto(Picture picture)
        {
            return new PictureDto
            {
                IdPicture = picture.IdPicture,
                Path = picture.Path,
                UpdateDate = picture.UpdateDate,
                MaintenanceCollection = picture.MaintenanceCollection.Select(MaintenanceMapper.MapToDto).ToList(),
                PlantCollection = picture.PlantCollection.Select(PlantMapper.MapToDto).ToList()
            };
        }

        public static Picture MapToEntity(PictureDto pictureDto)
        {
            return new Picture
            {
                IdPicture = pictureDto.IdPicture,
                Path = pictureDto.Path,
                UpdateDate = pictureDto.UpdateDate,
                MaintenanceCollection = pictureDto.MaintenanceCollection.Select(MaintenanceMapper.MapToEntity).ToList(),
                PlantCollection = pictureDto.PlantCollection.Select(PlantMapper.MapToEntity).ToList()
            };
        }
    }
}
