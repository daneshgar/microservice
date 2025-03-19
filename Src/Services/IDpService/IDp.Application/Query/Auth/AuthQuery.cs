using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth;
using MediatR;

namespace IDp.Application.Query.Auth
{
    public record AuthQuery:IRequest<JsonWebToken>
    {
        public required string mobileNumber { get; set; }
        public required int OtpCode { get; set; }
    }
}
