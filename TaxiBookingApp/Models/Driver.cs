using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiBookingApp.Models
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? VehicleId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Place { get; set; }
    }
}
