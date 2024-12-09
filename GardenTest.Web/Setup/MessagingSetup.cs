using GardenTest.Consumers;
using GardenTest.Models.Config;
using MassTransit;

namespace GardenTest.Setup;

public static class MessagingSetup
{
    public static WebApplicationBuilder AddMessaging(this WebApplicationBuilder services)
    {
        var rabbitConfig = new RabbitMqConfig();
        services.Configuration.GetSection("RabbitMq").Bind(rabbitConfig);

        services.Services.AddMassTransit(x =>
        {
            x.AddConsumer<SampleEventConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitConfig.Host, rabbitConfig.VirtualHost, h =>
                {
                    h.Username(rabbitConfig.Username);
                    h.Password(rabbitConfig.Password);
                });

                cfg.ConfigureEndpoints(context);
            });

        });
        
        return services;
    }
}