﻿using CoreApp.Model.DTO.Request;
using CoreApp.Model.DTO.Response;
using CoreApp.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class AuthencationController : ControllerBase
    {
        private readonly IAuthenticationService _authencationService;

        public AuthencationController(IAuthenticationService authencationService)
        {
            _authencationService = authencationService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto request)
        {
            return await _authencationService.Login(request);
        }

    }
}
