using Drunk.Unicorn.RussPass.Images.BI.Interfaces;
using Drunk.Unicorn.RussPass.Images.BI.Services;
using Drunk.Unicorn.RussPass.Images.BI.Options;
using Drunk.Unicorn.RussPass.Users.BI.Interfaces;
using Drunk.Unicorn.RussPass.Users.BI.Services;
using Drunk.Unicorn.RussPass.Kafka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient<ISearchClient, SerpClient>()
    .ConfigureHttpClient((serviceProvider, client) =>
    {
        var configuration = serviceProvider.GetRequiredService<IConfiguration>().GetSection("Search").Get<Config>();
        client.BaseAddress = new Uri(configuration.Url);
    })
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
    });

builder.Services.AddScoped<ISearch, Search>();
builder.Services.AddScoped<ICheck, Check>();
builder.Services.AddScoped<IKafkaProvider, KafkaProvider>();
builder.Services.AddSingleton<Keys>();
builder.Services.AddHttpClient<IFilesProvider, FilesObmennikProvider>()
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
