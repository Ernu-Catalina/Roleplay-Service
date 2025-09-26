using RoleplayService.Models;

namespace RoleplayService
{
    public class RoleplayRepository
    {
        private readonly RoleplayDbContext _context;
        public RoleplayRepository(RoleplayDbContext context) => _context = context;

        public IEnumerable<Character> GetCharacters() => _context.Characters.ToList();

        public void AddCharacter(Character c)
        {
            _context.Characters.Add(c);
            _context.SaveChanges();
        }
    }
}
