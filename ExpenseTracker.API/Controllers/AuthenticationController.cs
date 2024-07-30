﻿using ExpenseTracker.Application.Authentication;
using ExpenseTracker.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authenticationResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            var response = new AuthenticationResponse
            (
                authenticationResult.Id,
                authenticationResult.FirstName,
                authenticationResult.LastName,
                authenticationResult.Email,
                authenticationResult.Token
            );

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authenticationResult = _authenticationService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse
            (
                authenticationResult.Id,
                authenticationResult.FirstName,
                authenticationResult.LastName,
                authenticationResult.Email,
                authenticationResult.Token
            );

            return Ok(response);
        }
    }
}
