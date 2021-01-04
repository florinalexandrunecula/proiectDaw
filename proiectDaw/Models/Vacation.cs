using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDaw.Models
{
    public class Vacation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AnnualLeave { get; set; }
        [Required]
        public int BloodDonationLeave { get; set; }
        [Required]
        public int FourHourLeave { get; set; }
        [Required]
        public int SoftwareDeveloperId { get; set; }
        [Required]
        public SoftwareDeveloper SoftwareDeveloper { get; set; }
    }
}
