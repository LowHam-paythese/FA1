using System;
using System.ComponentModel.DataAnnotations;

namespace FA_1.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }

        [Required]
        public int CitizenID { get; set; }

        [Required]
        public string ReportType { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public string Status { get; set; }

        public Citizen Citizen { get; set; }
    }
}