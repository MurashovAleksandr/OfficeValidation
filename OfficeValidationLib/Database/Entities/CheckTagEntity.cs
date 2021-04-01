using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeValidationLib.Database.Entities
{
    [Table("CheckTag")]
    class CheckTagEntity : BaseEntity
    {
        [Column("IdTag")]
        [Required]
        public int IdTag { get; set; }

        [Column("IdCheck")]
        [Required]
        public int IdCheck { get; set; }
    }
}
