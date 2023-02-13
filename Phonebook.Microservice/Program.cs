using Microsoft.EntityFrameworkCore;
using Phonebook.Microservice.DbContexts;
using Phonebook.Microservice.Repositories;
using Phonebook.Microservice.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/phonebook_log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAddressPointService, AddressPointService>();
builder.Services.AddScoped<IAddressPointRepository, AddressPointRepository>();

builder.Logging.ClearProviders();
builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PhonebookContext>(options => 
    options.UseLazyLoadingProxies().UseSqlServer(connString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
