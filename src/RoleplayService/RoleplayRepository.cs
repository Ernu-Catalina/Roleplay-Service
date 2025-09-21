using System.Collections.Generic;
using System.Linq;

namespace RoleplayService
{
    public class RoleplayRepository
    {
        private readonly List<RoleAction> _actions = new();

        public IEnumerable<RoleAction> GetActions() => _actions;

        public void AddAction(RoleAction action) => _actions.Add(action);

        // This is the missing method
        public RoleAction PerformAction(RoleAction action)
        {
            // For now, just add the action to the list and mark it as success
            action.Status = "success";
            _actions.Add(action);
            return action;
        }
    }

    public class RoleAction
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string ActionName { get; set; } = string.Empty;
        public int TargetId { get; set; }
        public string Status { get; set; } = "pending";
    }
}
