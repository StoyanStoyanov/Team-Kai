namespace KaiFighterGame.UI
{
    using Factories;
    using GlobalConstants;
    using Microsoft.Xna.Framework;
    using Objects.DynamicObjects.Characters;
    using Utilities;

    public class PlayerHUD : UiObject
    {
        private Player playerInScene;
        private TextField health;
        private TextField score;
        private TextField damage;
        private string healthTitle;
        private string scoreTitle;
        private string damageTitle;

        public PlayerHUD(string fontFile, Color fontColor, Player somePlayer, float renderLayer) : base(fontColor, renderLayer)
        {
            this.ObjectColor = fontColor;
            this.playerInScene = somePlayer;
            this.healthTitle = "HP: ";
            this.scoreTitle = "Score: ";
            this.damageTitle = "Damage: ";
        }

        public override void Initialize()
        {
            this.health = (TextField)UiFactory.Instance.Create(
                FontAddresses.HudFont,
                this.healthTitle,
                this.ObjectColor,
                new Vector2(1120, 40),
                this.RenderLayer);
            SceneManager.AddObject(this.health);

            this.score = (TextField)UiFactory.Instance.Create(
                FontAddresses.HudFont,
                this.scoreTitle,
                this.ObjectColor,
                new Vector2(600, 40),
                this.RenderLayer);
            SceneManager.AddObject(this.score);

            this.damage = (TextField)UiFactory.Instance.Create(
                FontAddresses.HudFont,
                this.damageTitle,
                this.ObjectColor,
                new Vector2(40, 40),
                this.RenderLayer);
            SceneManager.AddObject(this.damage);
        }

        public override void Update(GameTime gameTime)
        {
            if ((int)this.playerInScene.Health < 0)
            {
                this.health.Text = string.Format("HP: {0}", 0);
            }
            else
            {
                this.health.Text = string.Format("HP: {0}", (int)this.playerInScene.Health);
            }
            
            this.score.Text = string.Format("Score: {0}", this.playerInScene.Score);
            this.damage.Text = string.Format("Damage: {0}", (int)this.playerInScene.Damage);
        }
    }
}