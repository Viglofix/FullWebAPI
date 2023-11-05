using DataBase.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class MorenModelHeroes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Hero { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = false;

    }
}
