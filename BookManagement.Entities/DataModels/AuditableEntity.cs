using BookManagement.Interface.Models;

namespace BookManagement.Entities.DataModels
{
    /// <summary>
    /// Auditable Entity
    /// </summary>
    public class AuditableEntity : IAuditableEntity
    {
        public bool IsAlive { get; set; }
    }
}
