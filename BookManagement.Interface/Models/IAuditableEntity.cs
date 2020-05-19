namespace BookManagement.Interface.Models
{
    /// <summary>
    /// Get and set alive value
    /// </summary>
    public interface IAuditableEntity
    {
        bool IsAlive { get; set; }
    }
}
