namespace KaiFighterGame.Scenes
{
    using Factories;
    using GlobalConstants;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using UI;
    using Utilities;
    using Microsoft.Xna.Framework.Media;

    public class MainMenu : ButtonController, IScene
    {
        private Button startGameButton;
        private Button statsButton;
        private Button exitGameButton;
        private Song menuSong;

        // scene initialization and object placement
        public void Load()
        {
            this.startGameButton = (Button) UiFactory.Instance.Create(
                Color.White,
                new Vector2(50, 50),
                ImageAddresses.NormalStartButton,
                ImageAddresses.HoveredStartButton,
                ImageAddresses.InactiveStartButton,
                RenderLayers.UiLayer,
                scale: .3f);
            SceneManager.AddObject(this.startGameButton);

            this.statsButton = (Button) UiFactory.Instance.Create(
                Color.White,
                new Vector2(50, 140),
                ImageAddresses.NormalStatsButton,
                ImageAddresses.HoveredStatsButton,
                ImageAddresses.InactiveStatsButton,
                RenderLayers.UiLayer,
                scale: .3f);
            SceneManager.AddObject(this.statsButton);

            this.exitGameButton = (Button) UiFactory.Instance.Create(
                Color.White,
                new Vector2(50, 230),
                ImageAddresses.NormalExitButton,
                ImageAddresses.HoveredExitButton,
                ImageAddresses.InactiveExitButton,
                RenderLayers.UiLayer,
                scale: .3f) as Button;
            SceneManager.AddObject(this.exitGameButton);

            Background backgr = (Background) UiFactory.Instance.Create(
                Color.White,
                ImageAddresses.MenuBackgroundImage,
                backgroundScale: .356f,
                backgroundLayer: RenderLayers.BackgroundLayer);
            SceneManager.AddObject(backgr);

            this.CurrentSelectedButton = this.startGameButton;

            this.Buttons.Add(this.startGameButton);
            this.Buttons.Add(this.statsButton);
            this.Buttons.Add(this.exitGameButton);

            this.startGameButton.OnPressed += this.LoadFirstLevel;
            this.exitGameButton.OnPressed += this.ExitGame;
            this.statsButton.OnPressed += this.LoadStatsLevel;

            this.menuSong = EntryPoint.TheGame.Content.Load<Song>(AudioAdresses.MenuSong);

            if (MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.Play(this.menuSong);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void LoadFirstLevel()
        {
            MediaPlayer.Stop();
            this.menuSong.Dispose();

            this.startGameButton.OnPressed -= this.LoadFirstLevel;
            this.statsButton.OnPressed -= this.LoadStatsLevel;
            this.exitGameButton.OnPressed -= this.ExitGame;

            SceneManager.LoadScene(new NormalLevel());
        }

        private void LoadStatsLevel()
        {
            this.startGameButton.OnPressed -= this.LoadFirstLevel;
            this.statsButton.OnPressed -= this.LoadStatsLevel;
            this.exitGameButton.OnPressed -= this.ExitGame;

            SceneManager.LoadScene(new StatsLevel());
        }

        private void ExitGame()
        {
            EntryPoint.TheGame.Exit();
        }
    }
}