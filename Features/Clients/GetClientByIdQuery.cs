using MediatR;
using AspNetIdentityServerGettingStarted.Data;
using AspNetIdentityServerGettingStarted.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Features.Clients
{
    public class GetClientByIdQuery
    {
        public class GetClientByIdRequest : IRequest<GetClientByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetClientByIdResponse
        {
            public ClientApiModel Client { get; set; } 
		}

        public class GetClientByIdHandler : IAsyncRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
        {
            public GetClientByIdHandler(AspNetIdentityServerGettingStartedDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetClientByIdResponse> Handle(GetClientByIdRequest request)
            {                
                return new GetClientByIdResponse()
                {
                    Client = ClientApiModel.FromClient(await _dataContext.Clients.FindAsync(request.Id))
                };
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
