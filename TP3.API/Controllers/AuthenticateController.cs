﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP3.API.ViewModel;
using TP3.ApplicationService;

namespace TP3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private AuthenticateService AuthenticateService { get; set; }

        public AuthenticateController(AuthenticateService service)
        {
            this.AuthenticateService = service;
        }

        [Route("Token")]
        [HttpPost]
        [RequireHttps]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                return await Task.FromResult(BadRequest(ModelState));

            var token = this.AuthenticateService.AuthenticateUser(loginRequest.Email, loginRequest.Nome);

            if (String.IsNullOrWhiteSpace(token))
            {
                return await Task.FromResult(BadRequest("Login ou senha Inválidos"));
            }

            return Ok(new
            {
                Token = token
            });

        }

    }
}
