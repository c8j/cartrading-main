using cartrade.persistence;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace cartradeTests.Factories;

public class CartradeApplicationFactory<Program> : WebApplicationFactory<Program> where Program : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment("Test");

        builder.ConfigureServices(
            services => services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("cartradeTestDB"))
        );

        return base.CreateHost(builder);
    }
}
