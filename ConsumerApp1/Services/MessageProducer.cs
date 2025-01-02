using GardenTest.Models;
using MassTransit;

namespace ConsumerApp1.Services
{
    public class MessageProducer : IMessageProducer
    {
        private IPublishEndpoint _endpoint;

        public MessageProducer(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }


        public async Task SendMessage()
        {
            var SampleEvent = new SampleEvent
            {
                Id = Guid.NewGuid(),
                Name = $"Test - {DateTime.UtcNow}"
            };

            await _endpoint.Publish(SampleEvent);
        }
    }
}
