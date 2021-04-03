using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace OfficeValidationLib.Database.Entities
{
    [Table("Violation")]
    public class ViolationEntity : BaseEntity
    {
        [Column("IdCheckResult"), Required]
        public long IdCheckResult { get; set; }

        [Column("IdViolationLevel"), Required]
        public long IdViolationLevel { get; set; }

        [Column("IdDocument"), Required]
        public long IdDocument { get; set; }

        [Column("ObjectName"), Required]
        public string ObjectName { get; set; }

        public CheckResultEntity GetCheckResultEntity(SQLiteConnection db) => db.Table<CheckResultEntity>().FirstOrDefault(x => x.Id == this.IdCheckResult);

        public ViolationLevelEntity GetViolationLevelEntity(SQLiteConnection db) => db.Table<ViolationLevelEntity>().FirstOrDefault(x => x.Id == this.IdViolationLevel);

        public DocumentEntity GetDocumentEntity(SQLiteConnection db) => db.Table<DocumentEntity>().FirstOrDefault(x => x.Id == this.IdDocument);

        public IEnumerable<ViolationDataEntity> GetViolationData(SQLiteConnection db) =>
            db.Table<ViolationDataEntity>().Where(x => x.IdViolation == this.Id);
    }
}
