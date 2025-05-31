using CompanyEmployees.Extensions;
using Service.Contracts;
using Service;
using NLog;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddApplicationPart(typeof(CompanyEmployees.Presentationn.AssemblyReference).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
