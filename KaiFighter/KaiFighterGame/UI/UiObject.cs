namespace KaiFighterGame.UI
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class UiObject : IRenderable
    {
        private Color objColor;
        private float renderLayer;

        public UiObject(Color objectColor, float layer)
        {
            this.ObjectColor = objectColor;
            this.RenderLayer = layer;
        }

        public Color ObjectColor
        {
            get
            {
                return this.objColor;
            }

            set
            {
                this.objColor = value;
            }
        }

        protected float RenderLayer
        {
            get
            {
                return this.renderLayer;
            }

            private set
            {
                this.renderLayer = value;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

        public virtual void Initialize()
        {
        }

        public virtual void LoadContent(Game theGame)
        {
        }

        public virtual void UnloadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}