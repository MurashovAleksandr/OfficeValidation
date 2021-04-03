using System.ComponentModel.DataAnnotations;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace OfficeValidationLib.Database.Entities
{
    [Table("ViolationLevel")]
    public class ViolationLevelEntity : BaseEntity
    {
        [Column("Name"), Required, Unique]
        public string Name { get; set; }
    }
}
