using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeValidationLib.Database.Entities
{
    [Table("Check")]
    class CheckEntity : BaseEntity
    {
        [Column("Name")]
        [Required]
        public string Name { get; set; }

        [Column("DisplayName")]
        [Required]
        public string DisplayName { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Active")]
        [Required]
        public bool Active { get; set; }

        [Column("Assembly")]
        [Required]
        public string Assembly { get; set; }

        [Column("ClassName")]
        [Required]
        public string ClassName { get; set; }
    }
}
