namespace Core
{
    /// <summary>
    /// State of entity. Use own ObjectState instead of EntityState 
    /// so that it will have no dependencies on EF and will be implemented by domain classes
    /// </summary>
    public enum ObjectState
    {
        Unchanged, Added, Modified, Deleted
    }
}