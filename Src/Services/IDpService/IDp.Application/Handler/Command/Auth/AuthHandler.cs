using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IDp.Application.Command.Auth;
using IDP.Domain.IRepository.Command;
using IDP.Domain.IRepository.Query;
using MediatR;

namespace IDp.Application.Handler.Command.Auth
{
    public class AuthHandler : IRequestHandler<AuthCommand, bool>
    {
        private readonly IOtpRedisRepository _otpRedisRepository;
        private readonly IMapper _mapper;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IUserCommandRepository _userCommandRepository;

        public AuthHandler(IOtpRedisRepository otpRedisRepository,
                           IMapper mapper,
                           IUserQueryRepository userQueryRepository,
                           IUserCommandRepository userCommandRepository
                           )
        {
            _otpRedisRepository = otpRedisRepository;
            _mapper = mapper;
            _userQueryRepository = userQueryRepository;
            _userCommandRepository = userCommandRepository;
        }
        public async Task<bool> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            try
            {
            var userobject = _mapper.Map<IDP.Domain.Entities.User>(request);
                var user = await _userQueryRepository.FindUserAsync(request.MobileNumber);
                Random random = new Random();
                var code = random.Next(1000, 10000);
                userobject.UserName = request.MobileNumber;

                if (user == null) 
                {
                    user=await _userCommandRepository.Insert(userobject);

                }
          var result=await   _otpRedisRepository.Insert(new IDP.Domain.DTO.Otp
            {
                IsUse = false,
                UserId = user.Id,
                Otpcode = code,
                UserName = user.UserName                
            });
               return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
