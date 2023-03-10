using SkiServiceApi.Models;
using SkiServiceApi.Services;

/// <summary>
/// Hauptprogramm, wo API startet, instanziierung von Services, API-KEY
/// </summary>
/// <param name="args"></param>

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
builder.Services.Configure<SkiServiceDatabaseSettings>(builder.Configuration.GetSection("SkiServiceDatabse"));


builder.Services.AddSingleton<ClientService>();
builder.Services.AddSingleton<MittarbieterService>();
builder.Services.AddSingleton<StatusService>();

// Hinzufügen von Services
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
