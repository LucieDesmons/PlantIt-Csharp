using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class PlantMapper
    {
        public static PlantDto MapToDto(Plant plant)
        {
            return new PlantDto
            {
                IdPlant = plant.IdPlant,
                Name = plant.Name,
                PlacePlant = plant.PlacePlant,
                Container = plant.Container,
                Humidity = plant.Humidity,
                Clarity = plant.Clarity,
                IdUser = plant.IdUser,
                IdPlantReference = plant.IdPlantReference,
                PlantReference = plant.PlantReference != null ? PlantReferenceMapper.MapToDto(plant.PlantReference) : null,
                User = plant.User != null ? UserMapper.MapToDto(plant.User) : null,
                ConversationCollection = plant.ConversationCollection?.Select(ConversationMapper.MapToDto).ToList(),
                PictureCollection = plant.PictureCollection?.Select(PictureMapper.MapToDto).ToList()
            };
        }

        public static Plant MapToEntity(PlantDto plantDto)
        {
            return new Plant
            {
                //IdPlant = plantDto.IdPlant,
                Name = plantDto.Name,
                PlacePlant = plantDto.PlacePlant,
                Container = plantDto.Container,
                Humidity = plantDto.Humidity,
                Clarity = plantDto.Clarity,
                IdUser = plantDto.IdUser,
                IdPlantReference = plantDto.IdPlantReference,
                PlantReference = plantDto.PlantReference != null ? PlantReferenceMapper.MapToEntity(plantDto.PlantReference) : null,
                User = plantDto.User != null ? UserMapper.MapToEntity(plantDto.User) : null,
                ConversationCollection = plantDto.ConversationCollection?.Select(ConversationMapper.MapToEntity).ToList(),
                PictureCollection = plantDto.PictureCollection?.Select(PictureMapper.MapToEntity).ToList()
            };
        }
    }
}
