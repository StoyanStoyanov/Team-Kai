namespace KaiFighterGame.Factories
{
    using Global_Constants;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using UI;

    public class UiFactory : AbstractUiFactory
    {
        public override IRenderable Create(Color? renderColor, Vector2 position, string normalImage, string hoveredImage, string pressedImage, float renderLayer = RenderLayers.UiLayer, float scale = 1f)
        {
            return new Button(renderColor, position, normalImage, hoveredImage, pressedImage, renderLayer, scale);
        }

        public override IRenderable Create(Color? backgroundColor, string backgroundImageFile, float backgroundScale, float backgroundLayer)
        {
            return new Background(backgroundColor, backgroundImageFile, backgroundScale, backgroundLayer);
        }
    }
}