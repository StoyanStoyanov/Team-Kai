namespace KaiFighterGame.Factories
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Objects.DynamicObjects.Characters;

    /// <summary>
    /// The abstract UI Renderable objects factory.
    /// </summary>
    public abstract class AbstractUiFactory
    {
        public abstract IRenderable Create(
            Color renderColor,
            Vector2 position,
            string normalImage,
            string hoveredImage,
            string pressedImage,
            float renderLayer,
            float scale
        );

        public abstract IRenderable Create(
            Color backgroundColor, 
            string backgroundImageFile, 
            float backgroundScale, 
            float backgroundLayer
        );

        public abstract IRenderable Create(
            Color hudColor,
            Player player, 
            float renderLayer);
    }
}