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
    public class RemoveScopeCommand
    {
        public class RemoveScopeRequest : IRequest<RemoveScopeResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveScopeResponse { }

        public class RemoveScopeHandler : IAsyncRequestHandler<RemoveScopeRequest, RemoveScopeResponse>
        {
            public RemoveScopeHandler(AspNetIdentityServerGettingStartedDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveScopeResponse> Handle(RemoveScopeRequest request)
            {
                var scope = await _dataContext.Scopes.FindAsync(request.Id);
                scope.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveScopeResponse();
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
