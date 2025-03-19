using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Domain.Entities;

namespace IDP.Domain.IRepository.Query
{
    public interface IUserQueryRepository
    {
        Task<User> FindUserAsync(string mobileNumber);
    }
}
