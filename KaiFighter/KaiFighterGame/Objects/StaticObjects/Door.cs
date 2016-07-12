namespace KaiFighterGame.Objects.StaticObjects
{
    using Microsoft.Xna.Framework;

    using Utilities;
    using Interfaces;
    using Scenes;

    public class Door : StaticObject
    {
        public Door(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth) 
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth)
        {
        }

        public override void RespondToCollision(ICollidable gameObject)
        {
            if (gameObject.ObjType == ObjectType.Player)
            {
                SceneManager.LoadScene(new HardLevel());
            }
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}