namespace ChoreMonitor.Api.Controllers
{
    using System.Threading.Tasks;
    using Create = ChoreMonitor.Features.Registrations.Create;
    using GetAll = ChoreMonitor.Features.Registrations.GetAll;
    using Delete = ChoreMonitor.Features.Registrations.Delete;
    using WeekDashboard = ChoreMonitor.Features.Registrations.WeekDashboard;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistrationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<GetAll.Result> GetAll([FromQuery] GetAll.Query query)
        {
            return _mediator.Send(query);
        }

        [HttpGet("dashboard")]
        public Task<WeekDashboard.Result> GetByPage([FromQuery] WeekDashboard.Query query)
        {
            return _mediator.Send(query);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Create.Command command)
        {
            Create.Result result = await _mediator.Send(command);
            return Created(GetUrl(result.Id), result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Delete.Command command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        private string GetUrl<T>(T id)
        {
            return $"{Request.Scheme}://{Request.Host}{Request.PathBase}{Request.Path}/{id}";
        }
    }
}
