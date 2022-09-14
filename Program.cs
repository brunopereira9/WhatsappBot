using Microsoft.EntityFrameworkCore;
using WhatsappBot.Business;
using WhatsappBot.Business.Interfaces;
using WhatsappBot.Context;
using WhatsappBot.Repositories;
using WhatsappBot.Repositories.Interfaces;
using WhatsappBot.Util.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("LiberaTudo", builder => builder
        .WithOrigins(
            "http://localhost:3000", 
            "https://localhost:3000", 
            "https://localhost:7003",
            "http://localhost:5217"
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//
builder.Services.AddDbContext<AppDbContext>(
    option => option.UseMySql(
        builder.Configuration.GetConnectionString("DatabaseLocal") !,
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DatabaseLocal"))
    )
);
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IPeopleBusiness, PeopleBusiness>();

static string FormatBaseAddress(string baseAddress) => $"{baseAddress}/";

builder.Services.AddHttpClient(ConfigurationConstants.WHATSAPP_API_CLIENT_FACTORY, client =>
{
    client.BaseAddress = new Uri(FormatBaseAddress(builder.Configuration[EnvironmentVariables.BASE_URL_WHATSAPP_API]));
    client.Timeout = TimeSpan.FromSeconds(60);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("LiberaTudo");//usado somente para facilitar, essa política não é segura para ambiente de produção

app.UseAuthorization();

app.MapControllers();

app.Run();
