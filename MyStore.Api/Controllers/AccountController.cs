using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MyStore.Domain.Account.Commands.UserCommands;
using MyStore.Domain.Services;

namespace MyStore.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class AccountController : BaseController
    {
        private readonly IUserApplicationService _service;

        public AccountController(IUserApplicationService userService)
        {
            _service = userService;
        }

        [HttpPost]
        [Route("account")]
        public Task<HttpResponseMessage> Post([FromBody] dynamic body)
        {
            var command = new RegisterUserCommand(
                email: (string)body.email, 
                username: (string)body.username,
                password:(string) body.password
                );

            var user = _service.Register(command);
            return CreateResponse(HttpStatusCode.Created, user);
        }
    }
}