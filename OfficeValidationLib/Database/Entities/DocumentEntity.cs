using System.ComponentModel.DataAnnotations;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace OfficeValidationLib.Database.Entities
{
    [Table("Document")]
    public class DocumentEntity : BaseEntity
    {
        [Column("Path"), Required]
        public string Path { get; set; }

        [Column("Type"), Required]
        public string Type { get; set; }

        [Column("Hash"), Required]
        public string Hash { get; set; }
    }
}
