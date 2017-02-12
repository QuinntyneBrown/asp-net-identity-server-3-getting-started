using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace AspNetIdentityServerGettingStarted.Features.Clients
{
    [Authorize]
    [RoutePrefix("api/client")]
    public class ClientController : ApiController
    {
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateClientCommand.AddOrUpdateClientResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateClientCommand.AddOrUpdateClientRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateClientCommand.AddOrUpdateClientResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateClientCommand.AddOrUpdateClientRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetClientsQuery.GetClientsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetClientsQuery.GetClientsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetClientByIdQuery.GetClientByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetClientByIdQuery.GetClientByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveClientCommand.RemoveClientResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveClientCommand.RemoveClientRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
