using System.Net.Http;
using System.Net.Http.Json;

namespace RoleplayApi.Services
{
    public class RoleLogicService
    {
        private readonly HttpClient _http;
        private readonly string _characterUrl;
        private readonly string _gameUrl;

        public RoleLogicService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _characterUrl = config["CharacterServiceUrl"];
            _gameUrl = config["GameServiceUrl"];
        }

        // Wrapper model for inventory responses
        private class InventoryResponse
        {
            public List<int>? Inventory { get; set; }
        }

        public async Task<string> PerformAbilityAsync(int roleId, int characterId, int targetId)
        {
            // 1. Get player inventory (wrapped JSON)
            var invResponse = await _http.GetFromJsonAsync<InventoryResponse>(
                $"{_characterUrl}/character/{characterId}/inventory");

            var inventory = invResponse?.Inventory ?? new List<int>();

            // 2. Get target role
            var targetRoleResp = await _http.GetFromJsonAsync<Dictionary<string, int>>(
                $"{_characterUrl}/character/{targetId}/role");

            var targetRole = targetRoleResp != null && targetRoleResp.ContainsKey("role_id")
                ? targetRoleResp["role_id"]
                : 0;

            // 3. Get target inventory
            var targetInvResponse = await _http.GetFromJsonAsync<InventoryResponse>(
                $"{_characterUrl}/character/{targetId}/inventory");

            var targetInventory = targetInvResponse?.Inventory ?? new List<int>();

            // === Example role ability logic ===
            if (roleId == 1 && inventory.Contains(14))
            {
                // Detective (uses Magnifying Glass)
                await _http.PostAsJsonAsync($"{_characterUrl}/character/{characterId}/inventory/use",
                    new { item_id = 14 });

                await _http.PostAsJsonAsync($"{_gameUrl}/update-status",
                    new { character_id = characterId, message = $"Investigated target {targetId}, role: {targetRole}" });

                return $"Detective: investigated target {targetId}, found role {targetRole}";
            }

            // Spy
            if (roleId == 2 && inventory.Contains(7))
            {
                await _http.PostAsJsonAsync($"{_characterUrl}/character/{characterId}/inventory/use",
                    new { item_id = 7 });

                await _http.PostAsJsonAsync($"{_gameUrl}/update-status",
                    new { character_id = characterId, message = $"Spied on target {targetId}" });

                return $"Spy: observed target {targetId}";
            }

            // Default
            return $"Performed ability for role {roleId}";
        }
    }
}
