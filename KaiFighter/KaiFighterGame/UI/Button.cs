namespace KaiFighterGame.UI
{
    using GlobalConstants;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Button : IRenderable
    {
        private Color? renderColor;
        private Texture2D currentButtonTexture;
        private Texture2D normalButtonTexture;
        private Texture2D hoveredButtonTexture;
        private Texture2D inactiveButtonTexture;
        private Rectangle buttonRect;
        private Vector2 position;
        private bool selected;
        private bool pressed;
        private string normalButtonImage;
        private string hoveredButtonImage;
        private string inactiveButtonImage;
        private float renderLayer;
        private float scale;

        public Button(
            Color? renderColor,
            Vector2 position,
            string normalImage,
            string hoveredImage,
            string inactiveImage,
            float renderLayer = RenderLayers.UiLayer,
            float scale = .5f)
        {
            this.renderColor = renderColor;
            this.position = position;
            this.normalButtonImage = normalImage;
            this.hoveredButtonImage = hoveredImage;
            this.inactiveButtonImage = inactiveImage;
            this.renderLayer = renderLayer;
            this.scale = scale;
        }

        public delegate void PressAction();

        public event PressAction OnPressed;

        public Color? ObjectColor
        {
            get
            {
                return this.renderColor;
            }

            set
            {
                this.renderColor = value;
            }
        }

        public void Initialize()
        {
            this.currentButtonTexture = this.normalButtonTexture;
        }

        public void LoadContent(Game theGame)
        {
            this.normalButtonTexture = theGame.Content.Load<Texture2D>(this.normalButtonImage);
            this.inactiveButtonTexture = theGame.Content.Load<Texture2D>(this.inactiveButtonImage);
            this.hoveredButtonTexture = theGame.Content.Load<Texture2D>(this.hoveredButtonImage);

            this.buttonRect = new Rectangle((int)this.position.X, (int)this.position.Y, (int)(this.normalButtonTexture.Width * this.scale), (int)(this.normalButtonTexture.Height * this.scale));
        }

        public void Update(GameTime gameTime)
        {
            if (this.pressed == true)
            {
                this.pressed = false;
                this.currentButtonTexture = this.inactiveButtonTexture;

                this.OnPressed?.Invoke();
            }
            else if (this.selected == true)
            {
                this.currentButtonTexture = this.hoveredButtonTexture;
            }
            else
            {
                this.currentButtonTexture = this.normalButtonTexture;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.currentButtonTexture, destinationRectangle: this.buttonRect, color: this.ObjectColor, layerDepth: this.renderLayer);
        }

        public void UnloadContent()
        {
            this.normalButtonTexture.Dispose();
            this.inactiveButtonTexture.Dispose();
            this.hoveredButtonTexture.Dispose();
        }

        public void SelectButton()
        {
            this.selected = true;
        }

        public void DeselectButton()
        {
            this.selected = false;
        }

        public void PressButton()
        {
            this.pressed = true;
        }
    }
}