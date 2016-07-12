namespace KaiFighterGame.Scenes
{
    using Factories;
    using GlobalConstants;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Objects.DynamicObjects.Characters;
    using Objects.DynamicObjects.Characters.Enemies;
    using Objects.StaticObjects;
    using UI;
    using Utilities;

    public class NormalLevel : IScene
    {
        private int enemyCount;
        private bool doorAdded;

        public void Load()
        {
            this.doorAdded = false;

            Background backgr = (Background)UiFactory.Instance.Create(
                Color.White,
                ImageAddresses.LevelBackgroundImage,
                .72f,
                RenderLayers.BackgroundLayer);
            SceneManager.AddObject(backgr);

            Player fighter = (Player)DynamicObjectFactory.Instance.Create(
                new Vector2(GameResolution.DefaultWidth - 300, GameResolution.DefaultHeight / 2),
                ImageAddresses.PlayerImage,
                ObjectType.Player,
                Color.White,
                scale: 0.6f,
                rotation: 0,
                layerDepth: RenderLayers.CharacterLayer,
                movementSpeed: 5f,
                damage: 100,
                health: 200,
                cooldown: 5);
            SceneManager.AddObject(fighter);

            Creep firstCreep = (Creep)DynamicObjectFactory.Instance.Create(
                new Vector2(205, 555),
                ImageAddresses.CreepImage,
                ObjectType.Creep,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: RenderLayers.CharacterLayer,
                movementSpeed: 1f,
                damage: 5,
                health: 100);
            firstCreep.OnDead += this.DecreaseEnemyCount;
            this.enemyCount += 1;
            SceneManager.AddObject(firstCreep);

            Creep secondCreep = (Creep)DynamicObjectFactory.Instance.Create(
                new Vector2(305, 555),
                ImageAddresses.CreepImage,
                ObjectType.Creep,
                Color.Red,
                scale: 0.5f,
                rotation: 0,
                layerDepth: RenderLayers.CharacterLayer,
                movementSpeed: 1f,
                damage: 5,
                health: 100);
            secondCreep.OnDead += this.DecreaseEnemyCount;
            this.enemyCount += 1;
            SceneManager.AddObject(secondCreep);

            Creep thirdCreep = (Creep)DynamicObjectFactory.Instance.Create(
                new Vector2(805, 405),
                ImageAddresses.CreepImage,
                ObjectType.Creep,
                Color.Blue,
                scale: 0.5f,
                rotation: 0,
                layerDepth: RenderLayers.CharacterLayer,
                movementSpeed: 1f,
                damage: 5,
                health: 100);
            thirdCreep.OnDead += this.DecreaseEnemyCount;
            this.enemyCount += 1;
            SceneManager.AddObject(thirdCreep);

            Wizard testWizard = (Wizard)DynamicObjectFactory.Instance.Create(
                new Vector2(405, 305),
                ImageAddresses.WizardImage,
                ObjectType.Wizard,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: RenderLayers.CharacterLayer,
                movementSpeed: 1f,
                damage: 5,
                health: 100);
            testWizard.OnDead += this.DecreaseEnemyCount;
            this.enemyCount += 1;
            SceneManager.AddObject(testWizard);

            Archer testArcher = (Archer)DynamicObjectFactory.Instance.Create(
                new Vector2(800, 500),
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
            testWizard.OnDead += this.DecreaseEnemyCount;
            this.enemyCount += 1;
            SceneManager.AddObject(testWizard);

            // Add player HUD
            PlayerHUD hud = (PlayerHUD)UiFactory.Instance.Create(
                FontAddresses.HudFont,
                Color.White,
                fighter,
                RenderLayers.UiLayer);
            SceneManager.AddObject(hud);

            Wall topWall = (Wall)StaticObjectFactory.Instance.Create(
                new Vector2(GameResolution.DefaultWidth / 2, 0),
                ImageAddresses.HorizontalWall,
                ObjectType.Wall,
                Color.DarkCyan,
                1f,
                0f,
                1f);
            SceneManager.AddObject(topWall);

            Wall bottomWall = (Wall)StaticObjectFactory.Instance.Create(
                new Vector2(GameResolution.DefaultWidth / 2, GameResolution.DefaultHeight),
                ImageAddresses.HorizontalWall,
                ObjectType.Wall,
                Color.DarkCyan,
                1f,
                0f,
                1f);
            SceneManager.AddObject(bottomWall);

            Wall rightWall = (Wall)StaticObjectFactory.Instance.Create(
                new Vector2(0, GameResolution.DefaultHeight),
                ImageAddresses.VerticalWall,
                ObjectType.Wall,
                Color.DarkCyan,
                1f,
                0f,
                1f);
            SceneManager.AddObject(rightWall);

            Wall leftWall = (Wall)StaticObjectFactory.Instance.Create(
                new Vector2(GameResolution.DefaultWidth, GameResolution.DefaultHeight),
                ImageAddresses.VerticalWall,
                ObjectType.Wall,
                Color.DarkCyan,
                1f,
                0f,
                1f);
            SceneManager.AddObject(leftWall);
        }

        public void Update(GameTime gameTime)
        {
            if (this.enemyCount <= 0 && this.doorAdded == false)
            {
                Door doorToNextLevel = (Door)StaticObjectFactory.Instance.Create(
                new Vector2(50, GameResolution.DefaultHeight / 2),
                ImageAddresses.DoorToNextLevelImage,
                ObjectType.Door,
                Color.White,
                .65f,
                0f,
                RenderLayers.UiLayer);
                SceneManager.AddObject(doorToNextLevel);

                this.doorAdded = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                EntryPoint.TheGame.Exit();
            }
        }

        private void DecreaseEnemyCount()
        {
            this.enemyCount -= 1;
        }
    }
}