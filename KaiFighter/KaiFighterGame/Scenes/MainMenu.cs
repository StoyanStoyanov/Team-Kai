namespace KaiFighterGame.Scenes
{
    using System.Collections.Generic;
    using Factories;
    using Global_Constants;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using UI;
    using Utilities;
    using Microsoft.Xna.Framework.Media;

    public class MainMenu : IScene
    {
        private Button currentSelectedButton;
        private List<Button> buttons = new List<Button>();
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private bool disableButtons = false;
        private Button startGameButton;
        private Button statsButton;
        private Button exitGameButton;
        private Song menuSong;

        // scene initialization and object placement
        public void Load()
        {
            this.startGameButton = UiFactory.Instance.Create(
                Color.White,
                new Vector2(50, 50),
                ImageAddresses.NormalStartButton,
                ImageAddresses.HoveredStartButton,
                ImageAddresses.InactiveStartButton,
                RenderLayers.UiLayer,
                scale: .3f) as Button;
            SceneManager.AddObject(this.startGameButton);

            this.statsButton = UiFactory.Instance.Create(
                Color.White,
                new Vector2(50, 140),
                ImageAddresses.NormalStatsButton,
                ImageAddresses.HoveredStatsButton,
                ImageAddresses.InactiveStatsButton,
                RenderLayers.UiLayer,
                scale: .3f) as Button;
            SceneManager.AddObject(this.statsButton);

            this.exitGameButton = UiFactory.Instance.Create(
                Color.White,
                new Vector2(50, 230),
                ImageAddresses.NormalExitButton,
                ImageAddresses.HoveredExitButton,
                ImageAddresses.InactiveExitButton,
                RenderLayers.UiLayer,
                scale: .3f) as Button;
            SceneManager.AddObject(this.exitGameButton);

            Background backgr = UiFactory.Instance.Create(
                Color.White,
                ImageAddresses.MenuBackgroundImage,
                backgroundScale: .356f,
                backgroundLayer: RenderLayers.BackgroundLayer) as Background;
            SceneManager.AddObject(backgr);

            this.currentSelectedButton = this.startGameButton;

            this.buttons.Add(this.startGameButton);
            this.buttons.Add(this.statsButton);
            this.buttons.Add(this.exitGameButton);

            this.startGameButton.OnPressed += this.LoadFirstLevel;
            this.exitGameButton.OnPressed += this.ExitGame;

            this.menuSong = EntryPoint.TheGame.Content.Load<Song>("Audio/menuSong");
            MediaPlayer.Play(this.menuSong);
        }

        public void Update(GameTime gameTime)
        {
            if (this.disableButtons == false)
            {
                this.currentKeyboardState = Keyboard.GetState();

                int currentSelectedButtonIndex = this.buttons.IndexOf(this.currentSelectedButton);

                this.currentSelectedButton.SelectButton();

                if (this.currentKeyboardState.IsKeyDown(Keys.Up) && this.previousKeyboardState.IsKeyUp(Keys.Up))
                {
                    this.currentSelectedButton.DeselectButton();

                    if (currentSelectedButtonIndex == 0)
                    {
                        this.currentSelectedButton = this.buttons[this.buttons.Count - 1];
                    }
                    else
                    {
                        this.currentSelectedButton = this.buttons[currentSelectedButtonIndex - 1];
                    }
                }
                else if (this.currentKeyboardState.IsKeyDown(Keys.Down) && this.previousKeyboardState.IsKeyUp(Keys.Down))
                {
                    this.currentSelectedButton.DeselectButton();

                    if (currentSelectedButtonIndex == this.buttons.Count - 1)
                    {
                        this.currentSelectedButton = this.buttons[0];
                    }
                    else
                    {
                        this.currentSelectedButton = this.buttons[currentSelectedButtonIndex + 1];
                    }
                }
                else if (this.currentKeyboardState.IsKeyDown(Keys.Enter))
                {
                    this.disableButtons = true;
                    this.currentSelectedButton.PressButton();
                }

                this.previousKeyboardState = this.currentKeyboardState;
            }
        }

        private void LoadFirstLevel()
        {
            MediaPlayer.Stop();
            this.menuSong.Dispose();

            this.startGameButton.OnPressed -= this.LoadFirstLevel;

            SceneManager.LoadScene(new NormalLevel());
        }

        private void ExitGame()
        {
            EntryPoint.TheGame.Exit();
        }
    }
}