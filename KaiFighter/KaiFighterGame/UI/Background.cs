namespace KaiFighterGame.UI
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Background : IRenderable
    {
        private Color color;
        private float scale;
        private float layer;
        private Texture2D backgroundImage;
        private string backgroundImageFile;
        private Rectangle backgroundRect;

        public Background(Color backgroundColor, string backgroundImageFile, float backgroundScale, float backgroundLayer)
        {
            this.color = backgroundColor;
            this.backgroundImageFile = backgroundImageFile;
            this.scale = backgroundScale;
            this.layer = backgroundLayer;
        }

        public Color ObjectColor
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.backgroundImage, destinationRectangle: this.backgroundRect, color: this.color, layerDepth: this.layer);
        }

        public void Initialize()
        {
            this.backgroundRect = new Rectangle(0, 0, (int)(this.backgroundImage.Width * this.scale), (int)(this.backgroundImage.Height * this.scale));
        }

        public void LoadContent(Game theGame)
        {
            this.backgroundImage = theGame.Content.Load<Texture2D>(this.backgroundImageFile);
        }

        public void UnloadContent()
        {
            this.backgroundImage.Dispose();
        }

        public void Update(GameTime gameTime)
        {
            // will need this later for animation
        }
    }
}