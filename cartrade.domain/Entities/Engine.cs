namespace cartrade.domain.Entities
{
    public class Engine
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Replace("-", "");
        public int HorsePower { get; set; }
        public int Capacity { get; set; }
    }
}
