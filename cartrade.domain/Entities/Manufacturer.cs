namespace cartrade.domain.Entities;

public class Manufacturer
{
    public string Id { get; set; } = Guid.NewGuid().ToString().Replace("-", "");
    public required string Name { get; set; }

    // Navigational properties...
    public IList<Vehicle> Vehicles { get; set; } = [];
}