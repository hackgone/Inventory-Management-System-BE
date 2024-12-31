using AllServices.DbService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;
using ApiCore.Dto;
using AutoMapper;
using ApiData.Enums;

namespace AllServices.AuthService
{
    public class AuthService:IAuthService
    {
        private IDbService<User> _userDbService;
        private readonly IMapper _mapper;
        private IDbService<UserRoleMapping> _userroleDbService;

        public AuthService(IDbService<User> userdbService, IMapper mapper, IDbService<UserRoleMapping> userroleDbService) { 
            _userDbService = userdbService;
            _mapper = mapper;
            _userroleDbService = userroleDbService;
        }

        public async Task SaveUserCred(Login UserRequest)
        {
            User UserObj =  _mapper.Map<User>(UserRequest);
            UserRoleMapping userRoleMapping = new UserRoleMapping();
            switch(UserRequest.UserRole)
            {
                case var role when Enum.TryParse<UserRoleEnums>(role, true, out var userRoleEnum):
                    userRoleMapping.UserRoleId = (int)userRoleEnum; 
                    break;
            }
            //System.Console.WriteLine(userRoleMapping.UserRoleId);
            //var userroleid = await _userroleDbService.GetDataByName(UserRequest.UserRole, "RoleName");
            await _userDbService.SaveData(UserObj);
            userRoleMapping.UserId = UserObj.Id;
            await _userroleDbService.SaveData(userRoleMapping);

        }
        public async Task<int> FindUserByEmail(String email)
        {
          return _userDbService.GetUserByExp(e => e.Email == email).FirstOrDefault().Id;
        }
        
    }
}
