namespace KaiFighterGame.Interfaces
{
    /// <summary>
    /// All objects which can take damage must implement this interface.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// Determines the object's health.
        /// </summary>
        double Health { get; set; }
    }
}