using Asp.Versioning;
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
    public class AuthController: IBaseController
    {
        public readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> login([FromBody]AuthQuery authQuery)
        {
            var request=_mediator.Send(authQuery);
            return Ok(request);
        }
    }
}
