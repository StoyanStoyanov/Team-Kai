namespace KaiFighterGame.Interfaces
{
    /// <summary>
    /// All objects which can change their position will implement this interface.
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// All IMovable objects must implement their own movement.
        /// </summary>
        void Move();
    }
}