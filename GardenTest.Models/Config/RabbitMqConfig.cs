namespace GardenTest.Models.Config;

public class RabbitMqConfig
{
    public string Host { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }
    
    public string VirtualHost { get; set; }

    public int Port { get; set; }
}