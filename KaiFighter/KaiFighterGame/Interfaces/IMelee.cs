namespace KaiFighterGame.Interfaces
{
    /// <summary>
    /// All objects which are melee fighters will implement this interface.
    /// </summary>
    public interface IMelee
    {
        /// <summary>
        /// Returns whether the object is a melee fighter.
        /// </summary>
        bool IsMeleeFighter { get; }
    }
}