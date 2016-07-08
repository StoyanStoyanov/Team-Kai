namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// All objects which can change their position must implement this interface.
    /// </summary>
    public interface IMovable
    {
        void MoveUp();

        void MoveDown();

        void MoveRight();

        void MoveLeft();

        void MoveTowards(Vector2 dest);

        void MoveWithoutStop(Vector2 direction);
    }
}