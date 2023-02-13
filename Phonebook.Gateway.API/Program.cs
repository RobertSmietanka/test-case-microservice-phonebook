using Phonebook.Gateway.WebAPI.Url;
using Phonebook.Gateway.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<ServiceUrls>(builder.Configuration.GetSection("ServiceUrls"));
builder.Services.AddHttpClient<IPhonebookService, PhonebookService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:Phonebook"]));

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
