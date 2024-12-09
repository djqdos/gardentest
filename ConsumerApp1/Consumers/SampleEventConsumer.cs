using GardenTest.Models;
using MassTransit;

namespace ConsumerApp1.Consumers;

public class SampleModelConsumer : IConsumer<SampleEvent>
{
    public Task Consume(ConsumeContext<SampleEvent> context)
    {
        throw new NotImplementedException();
    }
}