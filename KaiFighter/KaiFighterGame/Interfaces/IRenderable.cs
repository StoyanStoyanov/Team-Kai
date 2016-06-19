namespace KaiFighterGame.Interfaces
{
    using Utilities;

    /// <summary>
    /// All objects which are going to be rendered on the screen will implement this interface.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Returns the position of the object.
        /// </summary>
        Position GetObjectPosition();

        /// <summary>
        /// Returns the image of the object.
        /// </summary>
        string GetObjectImage();
    }
}