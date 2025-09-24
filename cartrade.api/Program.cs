using cartrade.persistence;

using Microsoft.EntityFrameworkCore;

namespace cartrade.api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        if (builder.Environment.EnvironmentName != "Test")
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("DevConnection"));
        });
        }

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapControllers();

        app.Run();
    }
}
