using System.ComponentModel.DataAnnotations;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace OfficeValidationLib.Database.Entities
{
    public abstract class BaseEntity
    {
        [PrimaryKey, AutoIncrement, Column("Id"), Required, Unique]
        public long Id { get; set; }
    }
}
