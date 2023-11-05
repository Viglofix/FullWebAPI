using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class MorenModelLocations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Location { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        public int AgeOfLocation { get; set; }
    }
}
