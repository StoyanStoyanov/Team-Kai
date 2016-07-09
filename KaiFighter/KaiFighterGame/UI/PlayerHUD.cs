namespace KaiFighterGame.UI
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Objects.DynamicObjects.Characters;
    using GlobalConstants;

    public class PlayerHUD : IRenderable
    {
        private SpriteFont font;
        private Color? hudColor;
        private Player playerInScene;
        private float layer;

        public PlayerHUD(Color? hudColor, Player player, float renderLayer)
        {
            this.hudColor = hudColor;
            this.layer = renderLayer;
            this.playerInScene = player;
        }

        public Color? ObjectColor
        {
            get
            {
                return this.hudColor;
            }

            set
            {
                this.hudColor = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, "HP: " + this.playerInScene.Health, new Vector2(1120, 40), (Color)this.hudColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, this.layer);
            spriteBatch.DrawString(this.font, "Score: " + this.playerInScene.Score, new Vector2(600, 40), (Color)this.hudColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, this.layer);
            spriteBatch.DrawString(this.font, "Damage: " + this.playerInScene.Damage, new Vector2(40, 40), (Color)this.hudColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, this.layer);
        }

        public virtual void Initialize()
        {
        }

        public void LoadContent(Game theGame)
        {
            this.font = theGame.Content.Load<SpriteFont>(FontAdresses.HudFont);
        }

        public virtual void UnloadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}