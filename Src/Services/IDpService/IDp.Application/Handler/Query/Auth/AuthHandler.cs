using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth;
using IDp.Application.Query.Auth;
using IDP.Domain.IRepository.Command;
using IDP.Domain.IRepository.Query;
using MediatR;

namespace IDp.Application.Handler.Query.Auth
{
    public class AuthHandler : IRequestHandler<AuthQuery, JsonWebToken>
    {
        public readonly IJwtHandler _jwtHandler;
        private readonly IOtpRedisRepository _otpRedisRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public AuthHandler(IJwtHandler jwtHandler,
                           IOtpRedisRepository otpRedisRepository,
                           IUserQueryRepository userQueryRepository)
        {
            _jwtHandler = jwtHandler;
            _otpRedisRepository = otpRedisRepository;
            _userQueryRepository = userQueryRepository;
        }
        public async Task<JsonWebToken> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _otpRedisRepository.GetData(request.mobileNumber);
                if (res == null) return null;
                if (res.Otpcode == request.OtpCode)
                {
                    var user=await _userQueryRepository.FindUserAsync(request.mobileNumber);
                   var token=_jwtHandler.Create(user.Id);
                    return token;
                }
                else
                {
                    return null;
                }


            }catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
