using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDp.Application.Command.Auth;
using IDP.Domain.IRepository.Command;
using MediatR;

namespace IDp.Application.Handler.Command.Auth
{
    public class AuthHandler : IRequestHandler<AuthCommand, bool>
    {
        private readonly IOtpRedisRepository _otpRedisRepository;
        public AuthHandler(IOtpRedisRepository otpRedisRepository)
        {
            _otpRedisRepository = otpRedisRepository;
        }
        public async Task<bool> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            _otpRedisRepository.Insert(new IDP.Domain.DTO.Otp
            {
                IsUse = false,
                UserId = 320,
                Otpcode = "DSADSA",
                UserName = "shabani"
            });
            return true;
        }
    }
}
