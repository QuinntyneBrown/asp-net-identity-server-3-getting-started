using MediatR;
using AspNetIdentityServerGettingStarted.Data;
using AspNetIdentityServerGettingStarted.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Features.Scopes
{
    public class GetScopeByIdQuery
    {
        public class GetScopeByIdRequest : IRequest<GetScopeByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetScopeByIdResponse
        {
            public ScopeApiModel Scope { get; set; } 
		}

        public class GetScopeByIdHandler : IAsyncRequestHandler<GetScopeByIdRequest, GetScopeByIdResponse>
        {
            public GetScopeByIdHandler(AspNetIdentityServerGettingStartedDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetScopeByIdResponse> Handle(GetScopeByIdRequest request)
            {                
                return new GetScopeByIdResponse()
                {
                    Scope = ScopeApiModel.FromScope(await _dataContext.Scopes.FindAsync(request.Id))
                };
            }

            private readonly AspNetIdentityServerGettingStartedDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
