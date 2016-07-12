namespace KaiFighterGame
{
    using GlobalConstants;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using Scenes;
    using Utilities;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class KaiFighterGame : Game
    {
        private Song fightMusic;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private bool canToggleFullScreen = true;

        public KaiFighterGame()
        {
            this.graphics = new GraphicsDeviceManager(this);

            // set resolution
            this.graphics.PreferredBackBufferWidth = GameResolution.DefaultWidth;
            this.graphics.PreferredBackBufferHeight = GameResolution.DefaultHeight;
            this.graphics.ApplyChanges();

            this.Content.RootDirectory = "Content";

            // set viewport scaling
            ScalingViewportAdapter.VirtualHeight = this.graphics.PreferredBackBufferHeight;
            ScalingViewportAdapter.VirtualWidth = this.graphics.PreferredBackBufferWidth;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            MediaPlayer.IsRepeating = true;

            SceneManager.LoadScene(new MainMenu());

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.fightMusic = EntryPoint.TheGame.Content.Load<Song>(AudioAddresses.FightSong);
            MediaPlayer.Play(this.fightMusic);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // toggle between full screen and windowed
            if (Keyboard.GetState().IsKeyDown(Keys.F) && this.canToggleFullScreen == true)
            {
                this.graphics.ToggleFullScreen();
                this.canToggleFullScreen = false;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.F) && this.canToggleFullScreen == false)
            {
                this.canToggleFullScreen = true;
            }

            SceneManager.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: ScalingViewportAdapter.GetScaleMatrix(this.GraphicsDevice));

            SceneManager.Draw(this.spriteBatch);

            this.spriteBatch.End();
        }
    }
}