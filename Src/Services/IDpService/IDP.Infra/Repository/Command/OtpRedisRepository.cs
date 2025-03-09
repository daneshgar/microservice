using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Domain.DTO;
using IDP.Domain.IRepository.Command;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;

namespace IDP.Infra.Repository.Command
{
    public class OtpRedisRepository : IOtpRedisRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConfiguration _configuration;

        public OtpRedisRepository(IDistributedCache distributedCache,IConfiguration configuration)
        {
            _distributedCache = distributedCache;
            _configuration = configuration;
        }
        public Task<bool> Delete(Otp entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Otp entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Otp entity)
        {
            throw new NotImplementedException();
        }
    }
}
