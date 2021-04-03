using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace OfficeValidationLib.Database.Entities
{
    [Table("CheckResult")]
    public class CheckResultEntity :  BaseEntity
    {
        [Column("IdCheck"), Required]
        public long IdCheck { get; set; }

        [Column("Date"), Required]
        public DateTime Date { get; set; }

        public CheckEntity GetCheckEntity(SQLiteConnection db) => db.Table<CheckEntity>().FirstOrDefault(x => x.Id == this.IdCheck);

        public IEnumerable<ViolationEntity> GetViolations(SQLiteConnection db) =>
            db.Table<ViolationEntity>().Where(x => x.IdCheckResult == this.Id);
    }
}
