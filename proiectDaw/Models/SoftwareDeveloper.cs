using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDaw.Models
{
    public class SoftwareDeveloper
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int HireYear { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public Project Project { get; set; }
    }
}
