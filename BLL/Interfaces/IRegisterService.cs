﻿using DATA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRegisterService
    {
        Task<AuthentificationDto> RegisterUser(RegisterModel model);
    }
}
