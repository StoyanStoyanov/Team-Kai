namespace KaiFighterGame
{
    using Factories;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Objects.DynamicObjects.Characters;
    using Utilities;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class KaiFighterGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private bool canToggleFullScreen = true;

        public KaiFighterGame()
        {
            this.graphics = new GraphicsDeviceManager(this);

            // set resolution
            this.graphics.PreferredBackBufferWidth = 1366;
            this.graphics.PreferredBackBufferHeight = 768;
            this.graphics.ApplyChanges();

            this.Content.RootDirectory = "Content";

            // set viewport scaling
            ScalingViewportAdapter.VirtualHeight = graphics.PreferredBackBufferHeight;
            ScalingViewportAdapter.VirtualWidth = graphics.PreferredBackBufferWidth;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            DynamicObjectFactory factory = new DynamicObjectFactory();

            // the next two lines should be performed by the factory
            Player firstFighter = factory.Create(new Vector2(200, 200), 
                "Images/Textures/PlayerTexture", 
                ObjectType.Player, 
                Color.White, 
                scale: 0.5f, 
                rotation: 0, 
                layerDepth: 1f, 
                movementSpeed: 5f,
                damage: 50, 
                health: 100,
                cooldown: 5,
                theGame: this) as Player;
            // add the fighter to the scene
            SceneManager.AddObject(firstFighter, this);

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

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
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
