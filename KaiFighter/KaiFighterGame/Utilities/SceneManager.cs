namespace KaiFighterGame.Utilities
{
    using System.Collections.Generic;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class SceneManager
    {
        private static readonly List<IRenderable> Objects = new List<IRenderable>();
        private static readonly List<ICollidable> CollidableObjects = new List<ICollidable>();
        private static IScene currentScene;

        /// <summary>
        /// Calls the update method of every object on the scene.
        /// </summary>
        /// <param name="gameTime">The game time object.</param>
        public static void Update(GameTime gameTime)
        {
            CollisionDispatcher.CheckCollision(CollidableObjects);

            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].Update(gameTime);
            }

            currentScene.Update(gameTime);
        }

        /// <summary>
        /// Calls the draw method of every object on the scene.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Adds object to the scene.
        /// </summary>
        /// <param name="obj">The renderable object to add to the scene.</param>
        public static void AddObject(IRenderable obj)
        {
            Objects.Add(obj);

            if (obj is ICollidable)
            {
                CollidableObjects.Add((ICollidable)obj);
            }

            obj.LoadContent(EntryPoint.TheGame);
            obj.Initialize();
        }

        /// <summary>
        /// Removes an object from the scene.
        /// </summary>
        /// <param name="obj">The object to remove.</param>
        public static void DestroyObject(IRenderable obj)
        {
            Objects.Remove(obj);

            if (obj is GameObject)
            {
                CollidableObjects.Remove((ICollidable)obj);
            }
        }

        /// <summary>
        /// Loads a scene.
        /// </summary>
        /// <param name="someScene">The scene to load.</param>
        public static void LoadScene(IScene someScene)
        {
            ClearScene();

            someScene.Load();

            currentScene = someScene;
        }

        /// <summary>
        /// Clears the scene at the end of each level.
        /// </summary>
        private static void ClearScene()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].UnloadContent();
            }

            EntryPoint.TheGame.Content.Unload();

            Objects.Clear();
            CollidableObjects.Clear();
        }
    }
}