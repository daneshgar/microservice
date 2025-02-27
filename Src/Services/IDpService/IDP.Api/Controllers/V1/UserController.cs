using Asp.Versioning;
using IDp.Application.Command.User;
using IDP.Api.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDP.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}/User")]
    public class UserController : IBaseController
    {
        public readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// add user info
        /// </summary>
        /// <returns></returns>
        /// 
        [MapToApiVersion("1.0")]
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody]UserCommand userCommand)
        {
            var rquest = await _mediator.Send(userCommand);
            return Ok(rquest);
        }
    }
}
