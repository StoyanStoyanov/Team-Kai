namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// All objects which can change their position will implement this interface.
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// All IMovable objects must implement their own movement.
        /// </summary>
        void MoveUp();

        void MoveDown();

        void MoveRight();

        void MoveLeft();

        void MoveTowards(Vector2 dest);

        void MoveWithoutStop(Vector2 direction);
    }
}