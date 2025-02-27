using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Domain.Entities.BaseEntities;

namespace IDP.Domain.Entities
{
    public class User : BaseEntitiy
    {
        public required string FullName { get; set; }
        public string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Salt { get; set; }
    }
}
