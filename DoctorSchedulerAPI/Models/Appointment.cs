using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorSchedulerAPI.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [ForeignKey("Doctor")]        
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Required]
        [ForeignKey("Patient")]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
        [Required]
        public DateTime AppFrom { get; set; }
        [Required]
        public DateTime AppTo { get; set; }
        public string Description { get; set; }
      
    }
}
