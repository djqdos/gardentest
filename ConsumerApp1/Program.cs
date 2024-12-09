// See https://aka.ms/new-console-template for more information


using ConsumerApp1.Services;
using ConsumerApp1.Setup;
using GardenTest.Models;
using GardenTest.Models.Config;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);
//IConfiguration configBuilder = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//    .Build();


builder.AddMessaging();

builder.Services.AddScoped<IMessageProducer, MessageProducer>();
builder.Services.AddHostedService<SampleBackgroundService>();

var app = builder.Build();




await app.RunAsync();