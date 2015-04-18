using System;

namespace Core.DataAccess.Entities
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }

        //string CreatedBy { get; set; }
        //string UpdatedBy { get; set; }
    }

    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set; }
    }
}