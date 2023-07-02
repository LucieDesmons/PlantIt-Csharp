using DATA.DTO;
using DATA.DTO.custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILoginService
    {
        AuthenticationDto Authenticate(LoginModel loginModel);

    }
}
