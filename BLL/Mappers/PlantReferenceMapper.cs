using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class PlantReferenceMapper
    {
        public static PlantReferenceDto MapToDto(PlantReference plantReference)
        {
            return new PlantReferenceDto
            {
                IdPlantReference = plantReference.IdPlantReference,
                Name = plantReference.Name,
                Family = plantReference.Family,
                Size = plantReference.Size,
                FoodSource = plantReference.FoodSource,
                Reproduction = plantReference.Reproduction,
                Lifetime = plantReference.Lifetime,
                PlaceLife = plantReference.PlaceLife,
                Description = plantReference.Description,
                CreatedByCollection = plantReference.CreatedByCollection.Select(CreatedByMapper.MapToDto).ToList(),
                PictureReferenceCollection = plantReference.PictureReferenceCollection.Select(PictureReferenceMapper.MapToDto).ToList(),
                PlantCollection = plantReference.PlantCollection.Select(PlantMapper.MapToDto).ToList()
            };
        }

        public static PlantReference MapToEntity(PlantReferenceDto plantReferenceDto)
        {
            return new PlantReference
            {
                IdPlantReference = plantReferenceDto.IdPlantReference,
                Name = plantReferenceDto.Name,
                Family = plantReferenceDto.Family,
                Size = plantReferenceDto.Size,
                FoodSource = plantReferenceDto.FoodSource,
                Reproduction = plantReferenceDto.Reproduction,
                Lifetime = plantReferenceDto.Lifetime,
                PlaceLife = plantReferenceDto.PlaceLife,
                Description = plantReferenceDto.Description,
                CreatedByCollection = plantReferenceDto.CreatedByCollection.Select(CreatedByMapper.MapToEntity).ToList(),
                PictureReferenceCollection = plantReferenceDto.PictureReferenceCollection.Select(PictureReferenceMapper.MapToEntity).ToList(),
                PlantCollection = plantReferenceDto.PlantCollection.Select(PlantMapper.MapToEntity).ToList()
            };
        }
    }
}
