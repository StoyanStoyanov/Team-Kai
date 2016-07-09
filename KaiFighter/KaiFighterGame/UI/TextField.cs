namespace KaiFighterGame.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TextField : UiObject
    {
        private SpriteFont font;
        private Vector2 textPosition;
        private string screenOutput;
        private string fontFile;

        public TextField(string fontFile, string text, Color fontColor, Vector2 position, float renderLayer) : base(fontColor, renderLayer)
        {
            this.fontFile = fontFile;
            this.Text = text;
            this.textPosition = position;
        }

        public string Text
        {
            get
            {
                return this.screenOutput;
            }

            set
            {
                this.screenOutput = value;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.screenOutput, this.textPosition, this.ObjectColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, this.RenderLayer);
        }

        public override void LoadContent(Game theGame)
        {
            this.font = theGame.Content.Load<SpriteFont>(this.fontFile);
        }
    }
}