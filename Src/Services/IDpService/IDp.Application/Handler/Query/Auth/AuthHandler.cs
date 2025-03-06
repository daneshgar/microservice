using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth;
using IDp.Application.Query.Auth;
using MediatR;

namespace IDp.Application.Handler.Query.Auth
{
    public class AuthHandler : IRequestHandler<AuthQuery, bool>
    {
        public readonly IJwtHandler _jwtHandler;

        public AuthHandler(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }
        public async Task<bool> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            var x=_jwtHandler.Create(34);
            return true;
        }
    }
}
