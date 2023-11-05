using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataBase.Models
{
    public class AutoMapperMorenHeroes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Hero { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = false;

        [StringLength(15)]
        [AllowNull]
        public string StatusCode { get; set; } = null;
    }
}
