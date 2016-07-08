namespace KaiFighterGame.Factories
{
    using Interfaces;
    using Microsoft.Xna.Framework;

    public abstract class AbstractUiFactory
    {
        public abstract IRenderable Create(
            Color? renderColor,
            Vector2 position,
            string normalImage,
            string hoveredImage,
            string pressedImage,
            float renderLayer,
            float scale);

        public abstract IRenderable Create(Color? backgroundColor, string backgroundImageFile, float backgroundScale, float backgroundLayer);
    }
}