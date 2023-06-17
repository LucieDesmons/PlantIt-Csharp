using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class CreatedByMapper
    {
        public static CreatedByDto MapToDto(CreatedBy createdBy)
        {
            return new CreatedByDto
            {
                IdPlantReference = createdBy.IdPlantReference,
                IdUser = createdBy.IdUser,
                OrderNum = createdBy.OrderNum,
                UpdateDate = createdBy.UpdateDate,
                PlantReference = PlantReferenceMapper.MapToDto(createdBy.PlantReference),
                User = UserMapper.MapToDto(createdBy.User)
            };
        }

        public static CreatedBy MapToEntity(CreatedByDto createdByDto)
        {
            return new CreatedBy
            {
                IdPlantReference = createdByDto.IdPlantReference,
                IdUser = createdByDto.IdUser,
                OrderNum = createdByDto.OrderNum,
                UpdateDate = createdByDto.UpdateDate,
                PlantReference = PlantReferenceMapper.MapToEntity(createdByDto.PlantReference),
                User = UserMapper.MapToEntity(createdByDto.User)
            };
        }
    }
}
