using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Domain.DTO;
using IDP.Domain.IRepository.Command.Base;


namespace IDP.Domain.IRepository.Command
{
    public interface IOtpRedisRepository:ICommandRepository<Otp>
    {
      
    }
}
