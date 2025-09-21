using Microsoft.AspNetCore.Mvc;

namespace RoleplayService.Controllers
{
    [ApiController]
    [Route("api/roleplay")]
    public class RoleplayController : ControllerBase
    {
        private readonly RoleplayRepository _repository;

        public RoleplayController(RoleplayRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("actions")]
        public IActionResult GetActions() => Ok(_repository.GetActions());

        [HttpPost("actions/perform")]
        public IActionResult PerformAction([FromBody] RoleAction action)
        {
            var result = _repository.PerformAction(action);
            return Ok(result);
        }
    }
}
