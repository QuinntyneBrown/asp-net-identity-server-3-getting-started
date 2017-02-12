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
    public class AddOrUpdateClientCommand
    {
        public class AddOrUpdateClientRequest : IRequest<AddOrUpdateClientResponse>
        {
            public ClientApiModel Client { get; set; }
        }

        public class AddOrUpdateClientResponse
        {

        }

        public class AddOrUpdateClientHandler : IAsyncRequestHandler<AddOrUpdateClientRequest, AddOrUpdateClientResponse>
        {
            public AddOrUpdateClientHandler(AspNetIdentityServerGettingStartedDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateClientResponse> Handle(AddOrUpdateClientRequest request)
            {
                var entity = await _dataContext.Clients
                    .SingleOrDefaultAsync(x => x.Id == request.Client.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Clients.Add(entity = new Client());
                entity.Name = request.Client.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateClientResponse()
                {

                };
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
