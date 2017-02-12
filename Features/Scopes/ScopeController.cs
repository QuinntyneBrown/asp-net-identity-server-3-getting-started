using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace AspNetIdentityServerGettingStarted.Features.Scopes
{
    [Authorize]
    [RoutePrefix("api/scope")]
    public class ScopeController : ApiController
    {
        public ScopeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateScopeCommand.AddOrUpdateScopeResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateScopeCommand.AddOrUpdateScopeRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateScopeCommand.AddOrUpdateScopeResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateScopeCommand.AddOrUpdateScopeRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetScopesQuery.GetScopesResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetScopesQuery.GetScopesRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetScopeByIdQuery.GetScopeByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetScopeByIdQuery.GetScopeByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveScopeCommand.RemoveScopeResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveScopeCommand.RemoveScopeRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
