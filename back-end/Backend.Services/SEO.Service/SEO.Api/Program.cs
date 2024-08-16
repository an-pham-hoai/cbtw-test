using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SEO.Domain.Implementations;
using SEO.Domain.Interfaces;
using SEOApi.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//add CORs
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
if (allowedOrigins != null) builder.Services.AddCustomCors(allowedOrigins);

//config dependency injections
builder.Services.AddScoped<ISEOService, SEOService>();
builder.Services.AddScoped<IGoogleService, GoogleService>();
builder.Services.AddScoped<IBingService, BingService>();
builder.Services.AddScoped<IFetchService, FetchService>();
builder.Services.AddScoped<IHTMLService, HTMLService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(); // Apply the CORS policy
app.UseAuthorization();

app.MapControllers();

app.Run();
