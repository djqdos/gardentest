
namespace ConsumerApp1.Services
{
    public class SampleBackgroundService(IServiceScopeFactory serviceScopeFactory) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();

            var messageProducer = scope.ServiceProvider.GetRequiredService<IMessageProducer>();


            while (!stoppingToken.IsCancellationRequested)
            {
                await messageProducer.SendMessage();
                await Task.Delay(10000);
            }


        }
    }
}
