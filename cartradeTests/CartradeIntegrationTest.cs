
using System.Text.Json;

using cartrade.api;
using cartrade.domain.Entities;
using cartrade.persistence;

using cartradeTests.Factories;

using Microsoft.Extensions.DependencyInjection;

using Xunit.Abstractions;

namespace cartradeTests;

public class CartradeIntegrationTest : IClassFixture<CartradeApplicationFactory<Program>>, IDisposable
{
    private readonly CartradeApplicationFactory<Program> _factory;
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _testOutputHelper;

    public CartradeIntegrationTest(CartradeApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        _factory = factory;
        _client = _factory.CreateClient();
        _testOutputHelper = testOutputHelper;
        SetupDatabase();
    }

    private void SetupDatabase()
    {
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();

        context.Vehicles.Add(
            new Vehicle
            {
                Manufacturer = new Manufacturer
                {
                    Name = "Volvo"
                },
                Model = new Model
                {
                    Name = "245DL"
                },
                ModelYear = "1982",
                Mileage = 165000,
                Engine = new Engine
                {
                    Capacity = 6000,
                    HorsePower = 150
                },
                FuelType = new FuelType
                {
                    Name = "Diesel"
                },
                MakeId = "1",
                EngineId = "1",
                FuelTypeId = "1",
                ModelId = "1",
                RegistrationNumber = "164758IRO",
                Transmission = new Transmission
                {
                    Name = "Automatic"
                },
                TransmissionId = "1"
            }
        );
    }

    [Fact]
    public async Task VehiclesController_ListVehicles_ShouldReturn_Vehicles()
    {
        // Act + Arrange...
        var result = await _client.GetAsync("https://localhost:5001/api/vehicles");
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine($"Content: {content}");

        var json = JsonDocument.Parse(content);
        var data = json.RootElement.GetProperty("data");
        var model = data[0].GetProperty("model").GetProperty("name").GetString();
        _testOutputHelper.WriteLine($"Model: {model}");

        Assert.Equal("245DL", model);
    }

    public void Dispose()
    {
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.EnsureDeleted();
        GC.SuppressFinalize(this);
    }
}
