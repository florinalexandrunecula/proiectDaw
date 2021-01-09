using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDaw.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string owner { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
    }
}
