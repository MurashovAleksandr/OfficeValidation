using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DocumentFormat.OpenXml.Math;

namespace OfficeValidationLib.Database.Entities
{
    [Table("CheckResult")]
    class CheckResultEntity : Base
    {
        [Column("IdCheck")]
        [Required]
        public int IdCheck { get; set; }

        [Column("Date")]
        [Required]
        public DateTime Date { get; set; }
    }
}
