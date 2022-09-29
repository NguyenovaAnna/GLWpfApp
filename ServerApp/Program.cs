using ServerApp;
using ServerApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Properties", "launchSettings.json"));

// Add services to the container.

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();

var applicationUrl = config.GetValue<string>("profiles:ServerApp:applicationUrl");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<SingletonService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
