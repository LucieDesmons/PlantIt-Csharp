using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Mappers
{
    public static class BankDetailMapper
    {
        public static BankDetailDto MapToDto(BankDetail bankDetail)
        {
            return new BankDetailDto
            {
                IdBankDetails = bankDetail.IdBankDetails,
                Details = bankDetail.Details,
                IdUser = bankDetail.IdUser,
                User = UserMapper.MapToDto(bankDetail.User)
            };
        }

        public static BankDetail MapToEntity(BankDetailDto bankDetailDto)
        {
            return new BankDetail
            {
                IdBankDetails = bankDetailDto.IdBankDetails,
                Details = bankDetailDto.Details,
                IdUser = bankDetailDto.IdUser,
                User = UserMapper.MapToEntity(bankDetailDto.User)
            };
        }
    }
}
