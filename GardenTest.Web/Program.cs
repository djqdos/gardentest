using GardenTest;
using GardenTest.Components;
using GardenTest.Hubs;
using GardenTest.Services.AdditionService;
using GardenTest.Setup;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Services
builder.Services.AddScoped<IAdditionService, AdditionService>();


// Add Mass Transit
builder.AddMessaging();


// DATABASE
builder.Services.AddDbContext<SampleDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// SIGNALR
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

//app.UseRouting();

app.MapHub<SampleHub>("/samplehub");

app.Run();