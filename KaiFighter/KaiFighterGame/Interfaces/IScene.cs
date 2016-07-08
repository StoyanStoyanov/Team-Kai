namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Defines a game scene.
    /// </summary>
    public interface IScene
    {
        void Load();

        void Update(GameTime gameTime);
    }
}