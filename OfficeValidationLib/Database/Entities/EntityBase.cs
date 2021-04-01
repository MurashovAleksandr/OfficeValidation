using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeValidationLib.Database.Entities
{
    class BaseEntity
    {
        [Column("ID")]
        [Required]
        public int Id { get; set; }
    }
}
