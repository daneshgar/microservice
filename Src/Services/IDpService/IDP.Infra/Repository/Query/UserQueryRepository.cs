using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Domain.Entities;
using IDP.Domain.IRepository.Query;
using IDP.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IDP.Infra.Repository.Query
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly ShopQueryDbContext _shopDbContext;

        public UserQueryRepository(ShopQueryDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<User> FindUserAsync(string mobileNumber)
        {
            var user = await _shopDbContext.Users.FirstOrDefaultAsync(x=>x.MobileNumber==mobileNumber);
            return user;

        }
    }
}
