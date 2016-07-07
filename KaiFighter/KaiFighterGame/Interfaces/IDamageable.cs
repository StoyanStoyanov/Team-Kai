namespace KaiFighterGame.Interfaces
{
    /// <summary>
    /// All objects which can take damage will implement this interface.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// Determines the object health
        /// </summary>
        double Health { get; set; }

        /// <summary>
        /// Determines how much damage the object will take when hit.
        /// </summary>
        void TakeDamage();
    }
}