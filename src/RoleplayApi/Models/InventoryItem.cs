namespace RoleplayApi.Models
{
    public class InventoryItem
    {
        public int Item_Id { get; set; }
        public string Item_Name { get; set; } = string.Empty;
        public int Uses { get; set; }
    }
}
