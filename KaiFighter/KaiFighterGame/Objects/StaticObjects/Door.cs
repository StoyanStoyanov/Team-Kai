namespace KaiFighterGame.Objects.StaticObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Media;

    using Utilities;
    using Interfaces;
    using Scenes;

    public class Door : StaticObject
    {
        public Door(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth) 
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth)
        {
        }

        public override void Initialize()
        {
            //throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();          
        }

        public override void RespondToCollision(ICollidable gameObject)
        {
            if (gameObject.ObjType == ObjectType.Player)
            {
                MediaPlayer.Stop();

                SceneManager.LoadScene(new HardLevel());
            }
        }
    }
}