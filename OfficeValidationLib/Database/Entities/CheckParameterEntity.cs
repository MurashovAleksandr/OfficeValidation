using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeValidationLib.Database.Entities
{
    [Table("CheckParameter")]
    class CheckParameterEntity : BaseEntity
    {
        [Column("IdCheck")]
        [Required]
        public int IdCheck { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }

        [Column("Value")]
        [Required]
        public string Value { get; set; }
    }
}
