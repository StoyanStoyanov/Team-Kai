namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities;

    /// <summary>
    /// All objects which are going to be rendered on the screen will implement this interface.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Returns the position of the object.
        /// </summary>
        Vector2 GetObjectPosition();

        /// <summary>
        /// Returns the image of the object.
        /// </summary>
        Texture2D GetObjectImage();
    }
}