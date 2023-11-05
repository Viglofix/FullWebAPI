using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DataBase.Models
{
    public class AutoMapperMorenLocations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Location { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        public int AgeOfLocation { get; set; }

        [StringLength(60)]
        public string OldOrYoung { get; set; }
    }
}
