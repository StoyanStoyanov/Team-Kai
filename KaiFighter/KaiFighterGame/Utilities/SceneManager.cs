using System.Diagnostics;
using KaiFighterGame.Factories;
using KaiFighterGame.Global_Constants;
using KaiFighterGame.Objects.StaticObjects;

namespace KaiFighterGame.Utilities
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Linq;

    public static class SceneManager
    {
        private static List<GameObject> objects = new List<GameObject>();
        private static StaticObjectFactory factory = new StaticObjectFactory();
        // Calls the update method of every object in the scene
        public static void Update(GameTime gameTime)
        {

             CollisionDispatcher.CheckCollision(objects);

            for (int i = 0; i < objects.Count; i++)
            {

                objects[i].Update(gameTime);
                if (objects[i].IsDestroyed)
                {
                    Debug.Write(objects[i].ObjType);
                    if (objects[i].ObjType != ObjectType.Bullet)
                    {
                        Bonus someBonus =
                            factory.Create(new Vector2(objects[i].PositionX, objects[i].PositionY),
                                ImageAddresses.BonusImage, ObjectType.Bonus, Color.White, 1f, 0f, 1f) as Bonus;
                        SceneManager.AddObject(someBonus, EntryPoint.TheGame);
                    }
                    SceneManager.DestroyObject(objects[i]);

                }

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
