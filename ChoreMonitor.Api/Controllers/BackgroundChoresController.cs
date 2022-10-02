namespace ChoreMonitor.Api.Controllers
{
    using Create = ChoreMonitor.Features.Chores.Create;
    using Microsoft.AspNetCore.Mvc;
    using ChoreMonitor.Api.BackgroundTasks;

    [ApiController]
    [Route("api/[controller]")]
    public class BackgroundchoresController : ControllerBase
    {
        private readonly ITaskQueue _taskQueue;

        public BackgroundchoresController(ITaskQueue taskQueue)
        {
            _taskQueue = taskQueue;
        }

        [HttpPost]
        public OkResult Create([FromBody]Create.Command command)
        {
            _taskQueue.Enqueue(command.Name);
            return Ok();
        }
    }
}
