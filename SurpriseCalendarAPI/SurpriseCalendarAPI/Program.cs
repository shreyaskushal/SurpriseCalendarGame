using Microsoft.EntityFrameworkCore;
using SurpriseCalendarAPI.Data;
using SurpriseCalendarAPI.Repositories;
using SurpriseCalendarAPI.Repositories.Interfaces;
using SurpriseCalendarAPI.Services;
using SurpriseCalendarAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SurpriseCalendarContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString")));

builder.Services.AddScoped<ISurpriseCalendarRepository, SurpriseCalendarRepository>();
builder.Services.AddScoped<ISurpriseCalendarService, SurpriseCalendarService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

//databse seeder logic should be moved to different project

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<SurpriseCalendarContext>();
        var repository = services.GetRequiredService<ISurpriseCalendarRepository>();
        repository.InitializeSurpriseCalendarAsync().Wait();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while seeding the database: " + ex.Message);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
