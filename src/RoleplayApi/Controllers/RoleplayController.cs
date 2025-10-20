using Microsoft.AspNetCore.Mvc;
using RoleplayApi.Models;
using RoleplayApi.Services;

namespace RoleplayApi.Controllers
{
    [ApiController]
    [Route("roleplay")]
    public class RoleplayController : ControllerBase
    {
        private readonly RoleLogicService _logic;

        public RoleplayController(RoleLogicService logic)
        {
            _logic = logic;
        }

        // Single endpoint for all role abilities
        [HttpPost("perform")]
        public async Task<IActionResult> PerformAbility([FromBody] RoleAbilityRequest request, [FromQuery] int role_id)
        {
            var result = await _logic.PerformAbilityAsync(role_id, request.Character_Id, request.Target_Id);
            return Ok(new { success = true, message = result });
        }
    }
}
