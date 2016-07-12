namespace KaiFighterGame.Scenes
{
    using System;
    using System.Timers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using Factories;
    using GlobalConstants;
    using Interfaces;
    using Objects.DynamicObjects.Characters;
    using Objects.DynamicObjects.Characters.Enemies;
    using Objects.StaticObjects;
    using UI;
    using Utilities;

    public class HardLevel : IScene
    {
        private readonly Random rand = new Random();
        private int enemyCount = 0;
        private Timer someTimer;

        public void Load()
        {
            this.someTimer = new Timer();
            this.someTimer.Interval = 2000;
            this.someTimer.Elapsed += new ElapsedEventHandler(this.LoadWin);                  

            Background backgr = (Background)UiFactory.Instance.Create(
                Color.White,
                ImageAddresses.HardLevelBackgroundImage,
                .7f,
                RenderLayers.BackgroundLayer);
            SceneManager.AddObject(backgr);

            Player fighter = (Player)DynamicObjectFactory.Instance.Create(
                new Vector2(GameResolution.DefaultWidth - 200, GameResolution.DefaultHeight / 2),
                ImageAddresses.PlayerImage,
                ObjectType.Player,
                Color.White,
                scale: 0.6f,
                rotation: 0,
                layerDepth: RenderLayers.CharacterLayer,
                movementSpeed: 5f,
                damage: 50,
                health: 100,
                cooldown: 5);
            SceneManager.AddObject(fighter);

            PlayerHUD hud = (PlayerHUD)UiFactory.Instance.Create(
                FontAddresses.HudFont,
                Color.White,
                fighter,
                RenderLayers.UiLayer);
            SceneManager.AddObject(hud);

            Boss testBoss = (Boss)DynamicObjectFactory.Instance.Create(
                 new Vector2(505, 505),
                 ImageAddresses.BossImage,
                 ObjectType.Boss,
                 Color.White,
                 scale: 1.5f,
                 rotation: 0,
                 layerDepth: RenderLayers.CharacterLayer,
                 movementSpeed: 1f,
                 damage: 10,
                 health: 1300);
            testBoss.OnDead += this.DecreaseEnemyCount;
            this.enemyCount += 1;

            SceneManager.AddObject(testBoss);

            Wall topWall = (Wall)StaticObjectFactory.Instance.Create(
                new Vector2(GameResolution.DefaultWidth / 2, 0),
                ImageAddresses.HorizontalWall,
                ObjectType.Wall,
                Color.Black,
                1f,
                0f,
                1f);
            SceneManager.AddObject(topWall);

            Wall bottomWall = (Wall)StaticObjectFactory.Instance.Create(
                new Vector2(GameResolution.DefaultWidth / 2, GameResolution.DefaultHeight),
                ImageAddresses.HorizontalWall,
                ObjectType.Wall,
                Color.Black,
                1f,
                0f,
                1f);
            SceneManager.AddObject(bottomWall);

            Wall rightWall = (Wall)StaticObjectFactory.Instance.Create(
                new Vector2(0, GameResolution.DefaultHeight),
                ImageAddresses.VerticalWall,
                ObjectType.Wall,
                Color.Black,
                1f,
                0f,
                1f);
            SceneManager.AddObject(rightWall);

            Wall leftWall = (Wall)StaticObjectFactory.Instance.Create(
                new Vector2(GameResolution.DefaultWidth, GameResolution.DefaultHeight),
                ImageAddresses.VerticalWall,
                ObjectType.Wall,
                Color.Black,
                1f,
                0f,
                1f);
            SceneManager.AddObject(leftWall);

            this.GenerateEnemiesAtRandomPositions();
        }

        public void Update(GameTime gameTime)
        {
            if (this.enemyCount <= 0)
            {
                this.someTimer.Start();

                return;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                EntryPoint.TheGame.Exit();
            }

            if (this.rand.Next(1, 1000) == 42)
            {
                this.GenerateEnemiesAtRandomPositions();
            }
        }

        private void GenerateEnemiesAtRandomPositions()
        {
            const int SpawnStartWith = 150;
            const int SpawnEndWidth = GameResolution.DefaultHeight - 150;
            const int SpawnStartHeight = 150;

            var spawnEndWidth = GameResolution.DefaultWidth - 300;

            for (int i = 0; i < 5; i++, spawnEndWidth -= 100)
            {
                var creep = (Creep)DynamicObjectFactory.Instance.Create(
                    new Vector2(this.rand.Next(SpawnStartWith, spawnEndWidth), this.rand.Next(SpawnStartHeight, SpawnEndWidth)),
                    ImageAddresses.CreepImage,
                    ObjectType.Creep,
                    Color.White,
                    scale: 0.5f,
                    rotation: 0,
                    layerDepth: RenderLayers.CharacterLayer,
                    movementSpeed: 1f,
                    damage: 5,
                    health: 100);
                SceneManager.AddObject(creep);
                creep.OnDead += this.DecreaseEnemyCount;

                var wizard = (Wizard)DynamicObjectFactory.Instance.Create(
                    new Vector2(this.rand.Next(SpawnStartWith, spawnEndWidth), this.rand.Next(SpawnStartHeight, SpawnEndWidth)),
                    ImageAddresses.WizardImage,
                    ObjectType.Wizard,
                    Color.White,
                    scale: 0.5f,
                    rotation: 0,
                    layerDepth: RenderLayers.CharacterLayer,
                    movementSpeed: 1f,
                    damage: 5,
                    health: 100);
                SceneManager.AddObject(wizard);
                wizard.OnDead += this.DecreaseEnemyCount;

                var archer = (Archer)DynamicObjectFactory.Instance.Create(
                    new Vector2(this.rand.Next(SpawnStartWith, spawnEndWidth), this.rand.Next(SpawnStartHeight, SpawnEndWidth)),
                    ImageAddresses.ArcherImage,
                    ObjectType.Archer,
                    Color.White,
                    scale: 0.5f,
                    rotation: 0,
                    layerDepth: RenderLayers.CharacterLayer,
                    movementSpeed: 1f,
                    damage: 5,
                    health: 100,
                    cooldown: 50);
                SceneManager.AddObject(archer);
                archer.OnDead += this.DecreaseEnemyCount;

                this.enemyCount += 3;
            }
        }

        private void DecreaseEnemyCount()
        {
            this.enemyCount -= 1;
        }

        private void LoadWin(object source, ElapsedEventArgs e)
        {
            this.someTimer.Stop();
            this.someTimer.Elapsed -= new ElapsedEventHandler(this.LoadWin);
            this.someTimer.Dispose();

            SceneManager.LoadScene(new WinScene());
        }
    }
}