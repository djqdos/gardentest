using GardenTest.Hubs;
using GardenTest.Models;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace GardenTest.Consumers;

public class SampleEventConsumer : IConsumer<SampleEvent>
{

    private readonly IHubContext<SampleHub> _sampleHub;


    public SampleEventConsumer(IHubContext<SampleHub> sampleHub)
    {
        _sampleHub = sampleHub; 
    }

    public async Task Consume(ConsumeContext<SampleEvent> context)
    {

        await _sampleHub.Clients.All.SendAsync("ReceiveMessage", context.Message.Id, context.Message.Name);

    }
}