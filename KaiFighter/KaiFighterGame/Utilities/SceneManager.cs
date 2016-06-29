﻿namespace KaiFighterGame.Utilities
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class SceneManager
    {
        private static List<GameObject> objects = new List<GameObject>();

        // Calls the update method of every object in the scene
        public static void Update(GameTime gameTime)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Update(gameTime);
            }
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
        public static void AddObject(GameObject obj, Game theGame)
        {
            objects.Add(obj);

            obj.Initialize();
            obj.LoadContent(theGame);
        }

        // destroys an object from the scene
        public static void DestroyObject(GameObject obj)
        {
            objects.Remove(obj);
        }

        // clears the scene. This should be performed after the end of each level
        public static void ClearScene()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].UnloadContent();
            }

            objects.Clear();
        }
    }
}
