using ApiCore.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllServices.AuthService
{
    public interface IAuthService
    {
        Task SaveUserCred(Login UserRequest);
        public Task<int> FindUserByEmail(String email);
    }
}
