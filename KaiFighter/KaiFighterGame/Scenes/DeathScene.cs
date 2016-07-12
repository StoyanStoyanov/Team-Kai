namespace KaiFighterGame.Scenes
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Factories;
    using GlobalConstants;
    using Microsoft.Xna.Framework.Input;
    using Utilities;

    public class DeathScene : IScene
    {
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public void Load()
        {
            var failBG = UiFactory.Instance.Create(
                Color.White,
                ImageAddresses.FailBackgroundImage,
                1f,
                RenderLayers.BackgroundLayer);
            SceneManager.AddObject(failBG);
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
