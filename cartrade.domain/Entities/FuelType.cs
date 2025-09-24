namespace cartrade.domain.Entities
{
    public class FuelType
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Replace("-", "");
        public required string Name { get; set; }
    }
}