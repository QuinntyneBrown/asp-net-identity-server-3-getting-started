using MediatR;
using AspNetIdentityServerGettingStarted.Data;
using AspNetIdentityServerGettingStarted.Data.Model;
using AspNetIdentityServerGettingStarted.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Features.Scopes
{
    public class AddOrUpdateScopeCommand
    {
        public class AddOrUpdateScopeRequest : IRequest<AddOrUpdateScopeResponse>
        {
            public ScopeApiModel Scope { get; set; }
        }

        public class AddOrUpdateScopeResponse
        {

        }

        public class AddOrUpdateScopeHandler : IAsyncRequestHandler<AddOrUpdateScopeRequest, AddOrUpdateScopeResponse>
        {
            public AddOrUpdateScopeHandler(AspNetIdentityServerGettingStartedDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateScopeResponse> Handle(AddOrUpdateScopeRequest request)
            {
                var entity = await _dataContext.Scopes
                    .SingleOrDefaultAsync(x => x.Id == request.Scope.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Scopes.Add(entity = new Scope());
                entity.Name = request.Scope.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateScopeResponse()
                {

                };
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
