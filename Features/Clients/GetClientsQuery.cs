using MediatR;
using AspNetIdentityServerGettingStarted.Data;
using AspNetIdentityServerGettingStarted.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Features.Clients
{
    public class GetClientsQuery
    {
        public class GetClientsRequest : IRequest<GetClientsResponse> { }

        public class GetClientsResponse
        {
            public ICollection<ClientApiModel> Clients { get; set; } = new HashSet<ClientApiModel>();
        }

        public class GetClientsHandler : IAsyncRequestHandler<GetClientsRequest, GetClientsResponse>
        {
            public GetClientsHandler(AspNetIdentityServerGettingStartedDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetClientsResponse> Handle(GetClientsRequest request)
            {
                var clients = await _dataContext.Clients.ToListAsync();
                return new GetClientsResponse()
                {
                    Clients = clients.Select(x => ClientApiModel.FromClient(x)).ToList()
                };
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
