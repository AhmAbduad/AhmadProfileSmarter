using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace AhmadProfileSmarter.Hubs
{
    public class EditorHub : Hub
    {
        // Join specific file room
        public async Task JoinFile(string fileId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, fileId);
        }

        // Send updates to others
        public async Task SendUpdate(string fileId, string content)
        {
            await Clients.OthersInGroup(fileId)
                .SendAsync("ReceiveUpdate", content);
        }
    }
}
