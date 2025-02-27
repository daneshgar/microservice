using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IDp.Application.Command.User
{
    public record UserCommand:IRequest<bool>
    {
        [Required(ErrorMessage ="Please Input Name ")]
        [MinLength(4)]
        public required string FullName { get; set; }
        public string Email { get; set; }
    }
}
