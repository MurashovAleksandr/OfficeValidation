using System.ComponentModel.DataAnnotations;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace OfficeValidationLib.Database.Entities
{
    [Table("ViolationData")]
    public class ViolationDataEntity : BaseEntity
    {
        [Column("Name"), Required]
        public string Name { get; set; }

        [Column("Value"), Required]
        public string Value { get; set; }

        [Column("IdViolation"), Required]
        public long IdViolation { get; set; }

        public ViolationEntity GetViolationEntity(SQLiteConnection db) => db.Table<ViolationEntity>().FirstOrDefault(x => x.Id == this.IdViolation);
    }
}
