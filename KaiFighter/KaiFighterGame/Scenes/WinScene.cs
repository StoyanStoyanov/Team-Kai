namespace KaiFighterGame.Scenes
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Factories;
    using GlobalConstants;
    using Microsoft.Xna.Framework.Input;
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
