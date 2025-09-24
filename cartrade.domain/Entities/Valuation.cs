namespace cartrade.domain.Entities
{
    public class Valuation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Replace("-", "");
        public int Value { get; set; }
        public bool ValueActive { get; set; }
        public DateTime ValuationDate { get; set; }
        public string? CommentValuation { get; set; }

        // Foreign keys...
        public required string VehicleId { get; set; }

        // Navigation properties...
        public required Vehicle Vehicle { get; set; }
    }
}