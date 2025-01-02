using Microsoft.AspNetCore.SignalR;

namespace GardenTest.Hubs
{
    public class SampleHub : Hub
    {
        public async Task Broadcast(Guid id, string name)
        {
            await Clients.All.SendAsync("ReceiveMessage", id, name);
        }
    }
}
