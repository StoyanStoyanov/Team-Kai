namespace KaiFighterGame.Factories
{
    using System;
    using Microsoft.Xna.Framework;

    using Interfaces;
    using GlobalConstants;
    using Objects.DynamicObjects.Characters;
    using UI;

    /// <summary>
    /// A thread-safe, lazy initialization Singleton implementation of the UI Renderable objects factory.
    /// </summary>
    public sealed class UiFactory : IUiFactory
    {
        /// <summary>
        /// Initializes an instance of the UiFactory class the first time
        /// an instance is required, and holds this instance ever since.
        /// </summary>
        private static readonly Lazy<UiFactory> Holder = new Lazy<UiFactory>(() => new UiFactory());

        /// <summary>
        /// Private constructor, ensures restricted access.
        /// </summary>
        private UiFactory()
        {
        }

        /// <summary>
        /// Provides access to the single instance of the UiFactory class.
        /// </summary>
        public static UiFactory Instance
        {
            get
            {
                return Holder.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderColor"></param>
        /// <param name="position"></param>
        /// <param name="normalImage"></param>
        /// <param name="hoveredImage"></param>
        /// <param name="pressedImage"></param>
        /// <param name="renderLayer"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public IRenderable Create(
            Color renderColor, 
            Vector2 position, 
            string normalImage, 
            string hoveredImage, 
            string pressedImage, 
            float renderLayer = RenderLayers.UiLayer, 
            float scale = 1f)
        {
            return new Button(renderColor, position, normalImage, hoveredImage, pressedImage, renderLayer, scale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="backgroundColor"></param>
        /// <param name="backgroundImageFile"></param>
        /// <param name="backgroundScale"></param>
        /// <param name="backgroundLayer"></param>
        /// <returns></returns>
        public IRenderable Create(Color backgroundColor, string backgroundImageFile, float backgroundScale, float backgroundLayer)
        {
            return new Background(backgroundColor, backgroundImageFile, backgroundScale, backgroundLayer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontFile"></param>
        /// <param name="fontColor"></param>
        /// <param name="somePlayer"></param>
        /// <param name="renderLayer"></param>
        /// <returns></returns>
        public IRenderable Create(string fontFile, Color fontColor, Player somePlayer, float renderLayer)
        {
            return new PlayerHUD(fontFile, fontColor, somePlayer, renderLayer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontFile"></param>
        /// <param name="text"></param>
        /// <param name="fontColor"></param>
        /// <param name="position"></param>
        /// <param name="renderLayer"></param>
        /// <returns></returns>
        public IRenderable Create(string fontFile, string text, Color fontColor, Vector2 position, float renderLayer)
        {
            return new TextField(fontFile, text, fontColor, position, renderLayer);
        }
    }
}