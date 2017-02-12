using MediatR;
using AspNetIdentityServerGettingStarted.Data;
using AspNetIdentityServerGettingStarted.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Features.Users
{
    public class RemoveUserCommand
    {
        public class RemoveUserRequest : IRequest<RemoveUserResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveUserResponse { }

        public class RemoveUserHandler : IAsyncRequestHandler<RemoveUserRequest, RemoveUserResponse>
        {
            public RemoveUserHandler(AspNetIdentityServerGettingStartedDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<RemoveUserResponse> Handle(RemoveUserRequest request)
            {
                var user = await _dataContext.Users.FindAsync(request.Id);
                user.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveUserResponse();
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
        }
    }
}
