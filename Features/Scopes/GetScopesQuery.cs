using MediatR;
using AspNetIdentityServerGettingStarted.Data;
using AspNetIdentityServerGettingStarted.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Features.Scopes
{
    public class GetScopesQuery
    {
        public class GetScopesRequest : IRequest<GetScopesResponse> { }

        public class GetScopesResponse
        {
            public ICollection<ScopeApiModel> Scopes { get; set; } = new HashSet<ScopeApiModel>();
        }

        public class GetScopesHandler : IAsyncRequestHandler<GetScopesRequest, GetScopesResponse>
        {
            public GetScopesHandler(AspNetIdentityServerGettingStartedDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetScopesResponse> Handle(GetScopesRequest request)
            {
                var scopes = await _dataContext.Scopes.ToListAsync();
                return new GetScopesResponse()
                {
                    Scopes = scopes.Select(x => ScopeApiModel.FromScope(x)).ToList()
                };
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
