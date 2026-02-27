using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;

namespace Presentaion
{
    public class AuthenticationController(IServiceManager serviceManager) : ApiController
    {
        #region Login
        //Authentication/Login
        [HttpPost("Login")]
        public async Task<ActionResult<UserResultDto>> Login(LoginDto loginDto)
        {
            var Result = await serviceManager.AuthenticationService.LoginAsync(loginDto);
            return Ok(Result);
        }

        #endregion
        #region Register
        [HttpPost("Register")]
        public async Task<ActionResult<UserResultDto>> Register(UserRegisterDto userRegisterDto)
        {
            var Result = await serviceManager.AuthenticationService.RegisterAsync(userRegisterDto);
            return Ok(Result);

        }
        #endregion
    }
}
