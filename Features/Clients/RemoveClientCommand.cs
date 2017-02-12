using MediatR;
using AspNetIdentityServerGettingStarted.Data;
using AspNetIdentityServerGettingStarted.Data.Model;
using AspNetIdentityServerGettingStarted.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Features.Clients
{
    public class RemoveClientCommand
    {
        public class RemoveClientRequest : IRequest<RemoveClientResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveClientResponse { }

        public class RemoveClientHandler : IAsyncRequestHandler<RemoveClientRequest, RemoveClientResponse>
        {
            public RemoveClientHandler(AspNetIdentityServerGettingStartedDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveClientResponse> Handle(RemoveClientRequest request)
            {
                var client = await _dataContext.Clients.FindAsync(request.Id);
                client.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveClientResponse();
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
