using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class MaintenanceMapper
    {
        public static MaintenanceDto MapToDto(Maintenance maintenance)
        {
            return new MaintenanceDto
            {
                IdMaintenance = maintenance.IdMaintenance,
                PredictedDate = maintenance.PredictedDate,
                RealizedDate = maintenance.RealizedDate,
                Report = maintenance.Report,
                PictureCollection = maintenance.PictureCollection.Select(PictureMapper.MapToDto).ToList(),
                UserCollection = maintenance.UserCollection.Select(UserMapper.MapToDto).ToList()
            };
        }

        public static Maintenance MapToEntity(MaintenanceDto maintenanceDto)
        {
            return new Maintenance
            {
                IdMaintenance = maintenanceDto.IdMaintenance,
                PredictedDate = maintenanceDto.PredictedDate,
                RealizedDate = maintenanceDto.RealizedDate,
                Report = maintenanceDto.Report,
                PictureCollection = maintenanceDto.PictureCollection.Select(PictureMapper.MapToEntity).ToList(),
                UserCollection = maintenanceDto.UserCollection.Select(UserMapper.MapToEntity).ToList()
            };
        }
    }
}
