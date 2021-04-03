using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace OfficeValidationLib.Database.Entities
{
    [Table("Check")]
    public class CheckEntity : BaseEntity
    {
        [Unique, Column("Name"), Required]
        public string Name { get; set; }

        [Column("DisplayName"), Required]
        public string DisplayName { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Active"), Required]
        public bool Active { get; set; }

        [Column("Assembly"), Required]
        public string Assembly { get; set; }

        [Column("ClassName"), Required]
        public string ClassName { get; set; }

        public IEnumerable<TagEntity> GetTagEntities(SQLiteConnection db)
        {
            var checkTagEntities = db.Table<CheckTagEntity>()
                .Where(x => x.IdCheck == this.Id)
                .ToArray();
            return db.Table<TagEntity>()
                .ToArray()
                .Where(x => checkTagEntities.Any(y => y.IdTag == x.Id));
        }

        public IEnumerable<CheckParameterEntity> GetCheckParameterEntities(SQLiteConnection db) =>
            db.Table<CheckParameterEntity>().Where(x => x.IdCheck == Id);
    }
}
