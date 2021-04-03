using System.ComponentModel.DataAnnotations;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace OfficeValidationLib.Database.Entities
{
    [Table("DocumentFactoryName")]
    public class DocumentFactoryNameEntity : BaseEntity
    {
        [Column("Name"), Required, Unique]
        public string Name { get; set; }

        [Column("Active"), Required]
        public bool Active { get; set; }
    }
}
