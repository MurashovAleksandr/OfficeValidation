using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SQLite.Net;

namespace OfficeValidationLib.Database.Entities
{
    [SQLite.Net.Attributes.Table("CheckParameter")]
    public class CheckParameterEntity : BaseEntity
    {
        [Column("IdCheck"), Required]
        public long IdCheck { get; set; }

        [SQLite.Net.Attributes.Column("Name"), Required]
        public string Name { get; set; }

        [SQLite.Net.Attributes.Column("Value"), Required]
        public string Value { get; set; }

        public CheckEntity GetCheckEntity(SQLiteConnection db) => db.Table<CheckEntity>().FirstOrDefault(x => x.Id == this.IdCheck);
    }
}
