using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IDp.Application.Command.Auth
{
    public class AuthCommand:IRequest<bool>
    {
        public required string MobileNumber {  get; set; }
    }
}
