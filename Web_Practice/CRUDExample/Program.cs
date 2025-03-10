using ServiceContracts;
using Services;
using Microsoft.EntityFrameworkCore;
using Entities;
using RepositoryContracts;
using Repositories;
using Entities.Data;
using Serilog;
using CRUDExample.Filters.ActionFilters;

var builder = WebApplication.CreateBuilder(args);

//Logging
builder.Host.ConfigureLogging(loggingProvider =>
{
	loggingProvider.ClearProviders();
	loggingProvider.AddConsole();
	loggingProvider.AddDebug();
	loggingProvider.AddEventLog();
});
//Serilog
builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
	loggerConfiguration
	.ReadFrom.Configuration(context.Configuration) //read configuration settings from built-in IConfiguration
	.ReadFrom.Services(services); //read out current app's services and make them available to serilog
});
//it adds controllers and views as services
builder.Services.AddControllersWithViews(options =>
{
	//options.Filters.Add<ResponseHeaderActionFilter>(5);

	var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<ResponseHeaderActionFilter>>();

	options.Filters.Add(new ResponseHeaderActionFilter(logger, "My-Key-From-Global", "My-Value-From-Global", 2));
});
builder.Services.AddControllersWithViews();

//add services into IoC container

builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();

builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IPersonsService, PersonsService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonsDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
builder.Services.AddHttpLogging(options =>
{
	options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestProperties | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders;
});

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

if (builder.Environment.IsEnvironment("Test") == false)
	Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");
app.Logger.LogDebug("debug-message");
app.Logger.LogInformation("information-message");
app.Logger.LogWarning("warning-message");
app.Logger.LogError("error-message");
app.Logger.LogCritical("critical-message");
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

public partial class Program


{ } //make the auto-generated Program accessible programmatically