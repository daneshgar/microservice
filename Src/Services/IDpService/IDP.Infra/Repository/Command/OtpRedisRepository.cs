using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using IDP.Domain.DTO;
using IDP.Domain.IRepository.Command;
using IDP.Domain.IRepository.Command.Base;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
        public async Task<bool> Delete(Otp entity)
        {
            _distributedCache.RefreshAsync(entity.UserName.ToString());
            return true;
        }

        public async Task<Otp> GetData(string Mobile)
        {
            var data=_distributedCache.GetString(Mobile);
            if (data == null)
                return null;
            var otpObject= JsonConvert.DeserializeObject<Otp>(data);
            return otpObject;
        }


        public Task<bool> Update(Otp entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Otp> Insert(Otp entity)
        {
            int time = Convert.ToInt32(_configuration.GetSection("Otp:OtpTime").Value);
            _distributedCache.SetString(entity.UserName.ToString(), JsonConvert.SerializeObject(entity), new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(time)));
            return null;
        }
    }
}
