using MediatR;
using AspNetIdentityServerGettingStarted.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Features.Users
{
    public class GetUsersQuery
    {
        public class GetUsersRequest : IRequest<GetUsersResponse> { }

        public class GetUsersResponse
        {
            public ICollection<UserApiModel> Users { get; set; } = new HashSet<UserApiModel>();
        }

        public class GetUsersHandler : IAsyncRequestHandler<GetUsersRequest, GetUsersResponse>
        {
            public GetUsersHandler(AspNetIdentityServerGettingStartedDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<GetUsersResponse> Handle(GetUsersRequest request)
            {
                var users = await _dataContext.Users.ToListAsync();
                return new GetUsersResponse()
                {
                    Users = users.Select(x => UserApiModel.FromUser(x)).ToList()
                };
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
        }

    }

}
