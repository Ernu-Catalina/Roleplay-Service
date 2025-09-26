using Microsoft.AspNetCore.Mvc;
using RoleplayService.Models;
using Microsoft.EntityFrameworkCore;

namespace RoleplayService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleplayController : ControllerBase
    {
        private readonly RoleplayDbContext _context;

        public RoleplayController(RoleplayDbContext context)
        {
            _context = context;
        }

        [HttpGet("characters")]
        public async Task<IActionResult> GetCharacters()
        {
            var characters = await _context.Characters.ToListAsync();
            return Ok(characters);
        }

        [HttpPost("characters")]
        public async Task<IActionResult> AddCharacter([FromBody] Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCharacters), new { id = character.Id }, character);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpPost("actions")]
        public async Task<IActionResult> AddAction([FromBody] RoleplayAction action)
        {
            _context.RoleplayActions.Add(action);
            await _context.SaveChangesAsync();
            return Ok(action);
        }
    }
}
