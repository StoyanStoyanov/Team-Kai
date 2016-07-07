namespace KaiFighterGame.Utilities
{
    using System.Collections.Generic;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class SceneManager
    {
        private static IScene currentScene;
        private static List<IRenderable> objects = new List<IRenderable>();

        // Calls the update method of every object in the scene
        public static void Update(GameTime gameTime)
        {
            // CollisionDispatcher.CheckCollision(objects);
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Update(gameTime);
            }

            currentScene.Update(gameTime);
        }

        // Calls the draw method of every object in the scene
        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(spriteBatch);
            }
        }

        // adds object to the scene
        public static void AddObject(IRenderable obj)
        {
            objects.Add(obj);

            obj.LoadContent(EntryPoint.TheGame);
            obj.Initialize();
        }

        // destroys an object from the scene
        public static void DestroyObject(GameObject obj)
        {
            objects.Remove(obj);
        }

        // loads a specified scene
        public static void LoadScene(IScene someScene)
        {
            ClearScene();

            someScene.Load();

            currentScene = someScene;
        }

        // clears the scene. This should be performed after the end of each level
        private static void ClearScene()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].UnloadContent();
            }

            objects.Clear();
        }
    }
}