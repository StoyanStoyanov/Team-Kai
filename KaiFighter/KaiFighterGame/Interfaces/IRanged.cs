namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// All ranged characters must implement this interface.
    /// </summary>
    public interface IRanged
    {
        /// <summary>
        /// All ranged characters must implement shooting.
        /// </summary>
        void Shoot(Vector2 direction);
    }
}