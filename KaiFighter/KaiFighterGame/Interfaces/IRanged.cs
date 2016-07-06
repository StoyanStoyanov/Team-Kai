namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// All objects which are range fighters will implement this interface.
    /// </summary>
    public interface IRanged
    {
        /// <summary>
        /// Returns whether the object is a range fighter.
        /// </summary>
        //// bool IsRanged { get; }
        void Shoot(Vector2 direction);
    }
}