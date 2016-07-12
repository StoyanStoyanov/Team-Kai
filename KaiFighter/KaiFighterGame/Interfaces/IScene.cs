namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Defines a game scene.
    /// </summary>
    public interface IScene
    {
        /// <summary>
        /// Defines a method for loading the scene.
        /// </summary>
        void Load();

        /// <summary>
        /// Defines a method for updating the scene.
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);
    }
}