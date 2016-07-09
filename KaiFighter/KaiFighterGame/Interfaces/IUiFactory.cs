namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;
    using Objects.DynamicObjects.Characters;

    /// <summary>
    /// The abstract UI Renderable objects factory.
    /// </summary>
    public interface IUiFactory
    {
        IRenderable Create(
            Color renderColor, 
            Vector2 position, 
            string normalImage, 
            string hoveredImage,
            string pressedImage, 
            float renderLayer, 
            float scale
        );

        IRenderable Create(Color backgroundColor, string backgroundImageFile, float backgroundScale, float backgroundLayer);

        IRenderable Create(string fontFile, Color fontColor, Player somePlayer, float renderLayer);

        IRenderable Create(string fontFile, string text, Color fontColor, Vector2 position, float renderLayer);
    }
}