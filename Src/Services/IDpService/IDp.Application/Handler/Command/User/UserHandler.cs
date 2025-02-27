using IDp.Application.Command.User;
using MediatR;

namespace IDp.Application.Handler.Command.User
{
    public class UserHandler : IRequestHandler<UserCommand, bool>
    {
        public async Task<bool> Handle(UserCommand request, CancellationToken cancellationToken)
        {
    
            return true;
        }
    }
}
