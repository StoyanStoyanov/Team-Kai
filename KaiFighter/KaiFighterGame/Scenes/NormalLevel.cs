namespace KaiFighterGame.Scenes
{
    using Factories;
    using Global_Constants;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Objects.DynamicObjects.Characters;
    using Objects.DynamicObjects.Characters.Enemies;
    using Objects.StaticObjects;
    using Utilities;

    public class NormalLevel : IScene
    {
        public void Load()
        {
            DynamicObjectFactory factory = new DynamicObjectFactory();

            // the next two lines should be performed by the factory
            Player fighter = factory.Create(
                new Vector2(500, 500),
                ImageAddresses.PlayerImage,
                ObjectType.Player,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: 1f,
                movementSpeed: 5f,
                damage: 50,
                health: 100,
                cooldown: 5) as Player;

            // add the fighter to the scene
            SceneManager.AddObject(fighter);

            // create first test creep and archer, maybe we should do array? Random cooldown, movement, speed ..... 
            Creep testCreep = factory.Create(
                new Vector2(205, 555),
                ImageAddresses.CreepImage,
                ObjectType.Creep,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: 1f,
                movementSpeed: 1f,
                damage: 5,
                health: 100) as Creep;

            SceneManager.AddObject(testCreep);

            Wizard testWizard = factory.Create(
                new Vector2(405, 305),
                ImageAddresses.WizardImage,
                ObjectType.Wizard,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: 1f,
                movementSpeed: 1f,
                damage: 5,
                health: 100) as Wizard;

            SceneManager.AddObject(testWizard);

            Archer testArcher = factory.Create(
                new Vector2(800, 500),
                ImageAddresses.ArcherImage,
                ObjectType.Archer,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: 1f,
                movementSpeed: 1f,
                damage: 5,
                health: 100,
                cooldown: 50) as Archer;

            SceneManager.AddObject(testArcher);

            StaticObjectFactory staticFactory = new StaticObjectFactory();

            // Adding all surronding walls
            for (int i = 0, horizontalUpdater = 0, verticalUpdater = 0; i < 8; i++)
            {
                Wall rightSide1Wall = staticFactory.Create(
                new Vector2(GameResolution.DefaultWidth, verticalUpdater),
                ImageAddresses.VerticalWallImage,
                ObjectType.Wall,
                Color.White,
                1f,
                0f,
                1f) as Wall;

                Wall leftSide2Wall = staticFactory.Create(
                new Vector2(0, verticalUpdater),
                ImageAddresses.VerticalWallImage,
                ObjectType.Wall,
                Color.White,
                1f,
                0f,
                1f) as Wall;

                Wall upperWall = staticFactory.Create(
                new Vector2(horizontalUpdater, 0),
                ImageAddresses.HorizonwalWallImage,
                ObjectType.Wall,
                Color.White,
                1f,
                0f,
                1f) as Wall;

                Wall downWall = staticFactory.Create(
                new Vector2(horizontalUpdater, GameResolution.DefaultHeight),
                ImageAddresses.HorizonwalWallImage,
                ObjectType.Wall,
                Color.White,
                1f,
                0f,
                1f) as Wall;

                SceneManager.AddObject(rightSide1Wall);
                SceneManager.AddObject(leftSide2Wall);
                SceneManager.AddObject(upperWall);
                SceneManager.AddObject(downWall);

                horizontalUpdater += 180;
                verticalUpdater += 90;
            }
        }

        public void Update(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }
    }
}