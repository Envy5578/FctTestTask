using FctTestTask.DAL;
using FctTestTask.DAL.Interfaces;
using FctTestTask.DAL.Repositories;
using FctTestTask.Domain.Entity;
using FctTestTask.Service.Implementations;
using FctTestTask.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

builder.Services.AddTransient<IShortLinkGenerationService, ShortLinkGenerationService>();
builder.Services.AddScoped<IBaseRepository<LinkEntity>, LinkRepository>();
builder.Services.AddScoped<ILinkService, LinkService>();

var connetionString = builder.Configuration.GetConnectionString("PgSql");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connetionString);
});

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
