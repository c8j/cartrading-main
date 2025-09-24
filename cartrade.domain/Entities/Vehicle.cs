using System.ComponentModel.DataAnnotations.Schema;

namespace cartrade.domain.Entities
{
    public class Vehicle
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Replace("-", "");
        public required string RegistrationNumber { get; set; }
        public bool IsValued { get; set; }
        public string? Comment { get; set; }
        public string? VinNumber { get; set; }
        public required string ModelYear { get; set; }
        public int? Mileage { get; set; }
        public int? Doors { get; set; }
        public int? Seats { get; set; }
        public string? Color { get; set; }

        // Foreign Keys...
        public required string MakeId { get; set; }
        public required string ModelId { get; set; }
        public required string FuelTypeId { get; set; }
        public required string TransmissionId { get; set; }
        public required string EngineId { get; set; }


        // Navigational properties...
        [ForeignKey("MakeId")]
        public required Manufacturer Manufacturer { get; set; }

        [ForeignKey("ModelId")]
        public required Model Model { get; set; }

        [ForeignKey("FuelTypeId")]
        public required FuelType FuelType { get; set; }

        [ForeignKey("TransmissionId")]
        public required Transmission Transmission { get; set; }

        [ForeignKey("EngineId")]
        public required Engine Engine { get; set; }

        public IList<Valuation> Valuations { get; set; } = [];

    }
}