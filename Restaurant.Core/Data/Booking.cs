using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Booking : Entity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNum { get; set; }

        [Required]
        public DateTime PreferredDateTime { get; set; }
        
        public string TableNo { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
