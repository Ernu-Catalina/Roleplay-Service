namespace RoleplayService
{
    public class RoleplayRepository
    {
        private readonly List<RoleAction> _actions = new();

        public List<RoleAction> GetActions() => _actions;

        public RoleAction PerformAction(RoleAction action)
        {
            action.ActionId = Guid.NewGuid();
            action.Status = "success";
            _actions.Add(action);
            return action;
        }
    }

    public class RoleAction
    {
        public Guid ActionId { get; set; }
        public int CharacterId { get; set; }
        public int? TargetId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Status { get; set; } = "pending";
        public string Details => $"Character {CharacterId} performed {Action}" + (TargetId != null ? $" on Character {TargetId}" : "");
    }
}
