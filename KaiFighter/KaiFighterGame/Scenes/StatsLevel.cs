namespace KaiFighterGame.Scenes
{
    using Factories;
    using GlobalConstants;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using UI;
    using Utilities;

    public class StatsLevel : ButtonController, IScene
    {
        private Button backButton;
        private Button clearStatsButton;
        private SpriteFont font;

        public void Load()
        {
            // used to draw the stats on the screen
            this.font = EntryPoint.TheGame.Content.Load<SpriteFont>(FontAdresses.HudFont);

            Background backgr = (Background)UiFactory.Instance.Create(
                Color.White,
                ImageAddresses.MenuBackgroundImage,
                backgroundScale: .356f,
                backgroundLayer: RenderLayers.BackgroundLayer);
            SceneManager.AddObject(backgr);

            this.backButton = (Button)UiFactory.Instance.Create(
                Color.White,
                new Vector2(50, 50),
                ImageAddresses.NormalBackButton,
                ImageAddresses.HoveredBackButton,
                ImageAddresses.InactiveBackButton,
                RenderLayers.UiLayer,
                scale: .8f);
            SceneManager.AddObject(this.backButton);

            this.clearStatsButton = (Button)UiFactory.Instance.Create(
                Color.White,
                new Vector2(50, 130),
                ImageAddresses.NormalClearStatsButton,
                ImageAddresses.HoveredClearStatsButton,
                ImageAddresses.InactiveClearStatsButton,
                RenderLayers.UiLayer,
                scale: .8f);
            SceneManager.AddObject(this.clearStatsButton);

            this.CurrentSelectedButton = this.backButton;

            this.Buttons.Add(this.backButton);
            this.Buttons.Add(this.clearStatsButton);

            this.backButton.OnPressed += this.LoadMenu;
            this.clearStatsButton.OnPressed += this.ClearStats;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void ClearStats()
        {
            this.backButton.OnPressed -= this.LoadMenu;
            this.clearStatsButton.OnPressed -= this.ClearStats;
        }

        private void LoadMenu()
        {
            this.backButton.OnPressed -= this.LoadMenu;
            this.clearStatsButton.OnPressed -= this.ClearStats;

            SceneManager.LoadScene(new MainMenu());
        }
    }
}