using System.ComponentModel.DataAnnotations;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace OfficeValidationLib.Database.Entities
{
    [Table("CheckTag")]
    public class CheckTagEntity : BaseEntity
    {
        [Column("IdTag"), Required]
        public long IdTag { get; set; }

        [Column("IdCheck"), Required]
        public long IdCheck { get; set; }

        public CheckEntity GetCheckEntity(SQLiteConnection db) => db.Table<CheckEntity>().FirstOrDefault(x => x.Id == this.IdCheck);

        public TagEntity GetTagEntity(SQLiteConnection db) => db.Table<TagEntity>().FirstOrDefault(x => x.Id == this.IdTag);
    }
}
