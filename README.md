Roleplay Service

The Roleplay Service handles all role-specific actions (heal, investigate, kill, etc.), announcements, and allowed actions.
It enforces game rules by checking game state, character role, and item availability.

---

Endpoints

1. Perform Role Action

POST /api/roleplay/actions/perform

Allows a character to perform a role-specific action.

Payload:

{
"lobbyId": 2001,
"characterId": 101,
"action": "investigate",
"targetId": 102
}

Success Response (200 OK):

{
"actionId": 7001,
"status": "success",
"details": "Character 101 investigated Character 102"
}

Failure Response (400 Bad Request):

{
"error": "Invalid action or requirements not met"
}

---

2. Get Allowed Actions

GET /api/roleplay/characters/{characterId}/actions

Returns what actions the character can currently perform.

Response (200 OK):

{
"characterId": 102,
"role": "Spy",
"allowedActions": ["create-rumor"]
}

---

3. Record Announcement

POST /api/roleplay/announcements

Stores a message visible to all players in the lobby.

Payload:

{
"lobbyId": 21,
"message": "The Mayor has spoken in Town Square."
}

Response (201 Created):

{
"announcementId": 91,
"lobbyId": 21,
"message": "The Mayor has spoken in Town Square."
}

---

How to Run the Service

1. Make sure you have .NET 10 SDK installed: https://aka.ms/dotnet-download
2. Open a terminal or PowerShell in the project root directory (where RoleplayService.csproj is located).
3. Restore dependencies:

   dotnet restore

4. Build the project:

   dotnet build

5. Run the service on localhost port 5001 (or any port you choose):

   dotnet run --urls http://localhost:5001

6. The API will be accessible at:

   http://localhost:5001/api/roleplay/actions/perform
   http://localhost:5001/api/roleplay/characters/{characterId}/actions
   http://localhost:5001/api/roleplay/announcements

Optional: You can also use the Python build_and_run.py script to automate steps 3-5:

python build_and_run.py
