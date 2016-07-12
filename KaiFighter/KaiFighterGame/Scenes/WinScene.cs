namespace KaiFighterGame.Scenes
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using Factories;
    using Interfaces;
    using GlobalConstants;
    using Utilities;

    public class WinScene : IScene
    {
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public void Load()
        {
            var winBG = UiFactory.Instance.Create(
                Color.White,
                ImageAddresses.WinBackgroundImage,
                1f,
                RenderLayers.BackgroundLayer);
            SceneManager.AddObject(winBG);
        }

        public void Update(GameTime gameTime)
        {
            this.previousKeyboardState = this.currentKeyboardState;
            this.currentKeyboardState = Keyboard.GetState();

            if (this.currentKeyboardState.IsKeyUp(Keys.Enter) && this.previousKeyboardState.IsKeyDown(Keys.Enter))
            {
                SceneManager.LoadScene(new MainMenu());
            }
        }
    }
}
