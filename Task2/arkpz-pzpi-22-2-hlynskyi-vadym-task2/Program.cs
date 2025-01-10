using LevelUp.Data;
using LevelUp.Interfaces;
using LevelUp.Repositories;
using LevelUp.Repository;
using LevelUpDB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<Seed>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<DataContext>();
        var seedService = services.GetRequiredService<Seed>(); 

        context.Database.Migrate(); 
        seedService.SeedDB(context); 
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred during seeding: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
