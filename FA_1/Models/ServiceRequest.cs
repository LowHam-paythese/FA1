using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FA_1.Models
{
    public class ServiceRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestID { get; set; }

        [ForeignKey("Citizen")]
        public int CitizenID { get; set; }

        public Citizen Citizen { get; set; }

        [Required]
        public string ServiceType { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";
    }
}