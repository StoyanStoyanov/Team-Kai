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
    using Utilities;

    public class NormalLevel : IScene
    {
        public void Load()
        {
            Player fighter = (Player) DynamicObjectFactory.Instance.Create(
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
                cooldown: 5
            );
            SceneManager.AddObject(fighter);

            Creep testCreep = (Creep) DynamicObjectFactory.Instance.Create(
                new Vector2(205, 555),
                ImageAddresses.CreepImage,
                ObjectType.Creep,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: 1f,
                movementSpeed: 1f,
                damage: 5,
                health: 100
            );
            SceneManager.AddObject(testCreep);

            Wizard testWizard = (Wizard) DynamicObjectFactory.Instance.Create(
                new Vector2(405, 305),
                ImageAddresses.WizardImage,
                ObjectType.Wizard,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: 1f,
                movementSpeed: 1f,
                damage: 5,
                health: 100
            );
            SceneManager.AddObject(testWizard);

            Archer testArcher = (Archer) DynamicObjectFactory.Instance.Create(
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
                cooldown: 50
            );
            SceneManager.AddObject(testArcher);

            // Adding all surronding walls
            for (int i = 0, updateX = 0, updateY = 0; i < 8; i++)
            {
                Wall rightSideWall = (Wall)StaticObjectFactory.Instance.Create(
                    new Vector2(GameResolution.DefaultWidth, updateY),
                    ImageAddresses.VerticalWallImage,
                    ObjectType.Wall,
                    Color.White,
                    1f,
                    0f,
                    1f
                );

                Wall leftSideWall = (Wall)StaticObjectFactory.Instance.Create(
                    new Vector2(0, updateY),
                    ImageAddresses.VerticalWallImage,
                    ObjectType.Wall,
                    Color.White,
                    1f,
                    0f,
                    1f
                );

                Wall upperWall = (Wall) StaticObjectFactory.Instance.Create(
                    new Vector2(updateX, 0),
                    ImageAddresses.HorizontalWallImage,
                    ObjectType.Wall,
                    Color.White,
                    1f,
                    0f,
                    1f
                );

                Wall bottomWall = (Wall)StaticObjectFactory.Instance.Create(
                    new Vector2(updateX, GameResolution.DefaultHeight),
                    ImageAddresses.HorizontalWallImage,
                    ObjectType.Wall,
                    Color.White,
                    1f,
                    0f,
                    1f
                );

                SceneManager.AddObject(rightSideWall);
                SceneManager.AddObject(leftSideWall);
                SceneManager.AddObject(upperWall);
                SceneManager.AddObject(bottomWall);

                updateX += 180;
                updateY += 90;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                EntryPoint.TheGame.Exit();
            }
        }
    }
}