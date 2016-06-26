namespace KaiFighterGame.Interfaces
{
    /// <summary>
    /// All objects which are range fighters will implement this interface.
    /// </summary>
    public interface IRanged
    {
        /// <summary>
        /// Returns whether the object is a range fighter.
        /// </summary>
        bool IsRanged { get; }
    }
}