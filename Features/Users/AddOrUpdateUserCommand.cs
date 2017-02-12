using MediatR;
using AspNetIdentityServerGettingStarted.Data;
using AspNetIdentityServerGettingStarted.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Features.Users
{
    public class AddOrUpdateUserCommand
    {
        public class AddOrUpdateUserRequest : IRequest<AddOrUpdateUserResponse>
        {
            public UserApiModel User { get; set; }
        }

        public class AddOrUpdateUserResponse
        {

        }

        public class AddOrUpdateUserHandler : IAsyncRequestHandler<AddOrUpdateUserRequest, AddOrUpdateUserResponse>
        {
            public AddOrUpdateUserHandler(AspNetIdentityServerGettingStartedDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<AddOrUpdateUserResponse> Handle(AddOrUpdateUserRequest request)
            {
                var entity = await _dataContext.Users
                    .SingleOrDefaultAsync(x => x.Id == request.User.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Users.Add(entity = new User());
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateUserResponse()
                {

                };
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
        }

    }

}
