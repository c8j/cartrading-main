namespace cartrade.domain.Entities
{
    public class Transmission
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Replace("-", "");
        public required string Name { get; set; }
    }
}