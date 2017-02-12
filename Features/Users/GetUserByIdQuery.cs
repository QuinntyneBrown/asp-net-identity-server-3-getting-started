using MediatR;
using AspNetIdentityServerGettingStarted.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Features.Users
{
    public class GetUserByIdQuery
    {
        public class GetUserByIdRequest : IRequest<GetUserByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetUserByIdResponse
        {
            public UserApiModel User { get; set; } 
		}

        public class GetUserByIdHandler : IAsyncRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
        {
            public GetUserByIdHandler(AspNetIdentityServerGettingStartedDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request)
            {                
                return new GetUserByIdResponse()
                {
                    User = UserApiModel.FromUser(await _dataContext.Users.FindAsync(request.Id))
                };
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
        }

    }

}
