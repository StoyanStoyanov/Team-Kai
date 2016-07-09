namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// All objects which are going to be rendered on the screen must implement this interface.
    /// </summary>
    public interface IRenderable
    {
        Color ObjectColor { get; set; }

        void Initialize();

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        void LoadContent(Game theGame);

        void UnloadContent();
    }
}