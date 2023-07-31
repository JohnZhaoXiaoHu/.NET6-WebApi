﻿using Application.Features.Users.Commands;
using Application.Features.Users.Queries;
using Application.Wrappers.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IResponse> GetAuthenticatedUserWithRolesAsync()
        {
            return await _mediator.Send(new GetAuthenticatedUserWithRolesQuery(UserId.Value));
        }

        [HttpPost("login")]
        public async Task<IResponse> Login(LoginCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("register")]
        public async Task<IResponse> Register(RegisterCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("refreshtoken")]
        public async Task<IResponse> RefreshToken(CreateTokenByRefreshTokenCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}