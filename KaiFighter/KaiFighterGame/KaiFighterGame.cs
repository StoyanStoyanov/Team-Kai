﻿using KaiFighterGame.Global_Constants;
using KaiFighterGame.Objects.DynamicObjects.Characters.Enemies;

namespace KaiFighterGame
{
    using Factories;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Objects.DynamicObjects.Characters;
    using Utilities;
    using Objects.StaticObjects;

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
            DynamicObjectFactory factory = new DynamicObjectFactory();

            // the next two lines should be performed by the factory
            Player firstFighter = factory.Create(
                new Vector2(200, 200),
                ImageAddresses.playerImage,
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

            //create first test creep and archer, maybe we should do array? Random cooldown, movement, speed ..... 

            Creep testCreep = factory.Create(new Vector2(205, 555),
                ImageAddresses.creepImage,
                ObjectType.Creep,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: 1f,
                movementSpeed: 1f,
                damage: 5,
                health: 100) as Creep;

            SceneManager.AddObject(testCreep, this);

            Wizard testWizard = factory.Create(new Vector2(405, 305),
                ImageAddresses.wizardImage,
                ObjectType.Wizard,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: 1f,
                movementSpeed: 1f,
                damage: 5,
                health: 100) as Wizard;

            SceneManager.AddObject(testWizard, this);

            Archer testArcher = factory.Create(new Vector2(800, 500),
                ImageAddresses.archerImage,
                ObjectType.Archer,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: 1f,
                movementSpeed: 1f,
                damage: 5,
                health: 100,
                cooldown: 50,
                theGame: this) as Archer;

            SceneManager.AddObject(testArcher, this);


            StaticObjectFactory staticFactory = new StaticObjectFactory();

            // create a wall for testing purposes
            Wall testWall = staticFactory.Create(
                new Vector2(100, 500),
                "Images/Statics/line",
                ObjectType.Wall,
                Color.Red,
                1f,
                0f,
                1f) as Wall;

            // add the wall to the scene
            SceneManager.AddObject(testWall, this);

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
