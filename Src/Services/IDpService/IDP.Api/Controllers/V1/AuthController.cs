﻿using Asp.Versioning;
using IDp.Application.Command.Auth;
using IDp.Application.Query.Auth;
using IDP.Api.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IDP.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}/Auth")]
    public class AuthController: ControllerBase
    {
        public readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody]AuthQuery authQuery)
        {
            var request=await _mediator.Send(authQuery);
            return Ok(request);
        }
        [HttpPost("SendOtp")]
        public async Task<IActionResult> SendOtp([FromBody]AuthCommand authCommand)
        {
            var request=await _mediator.Send(authCommand);
            return Ok(request);
        }
    }
}
