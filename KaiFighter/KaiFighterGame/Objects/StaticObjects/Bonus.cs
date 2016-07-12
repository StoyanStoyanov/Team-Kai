namespace KaiFighterGame.Objects.StaticObjects
{
    using Microsoft.Xna.Framework;

    using Utilities;
    using Interfaces;

    public class Bonus : StaticObject
    {
        public Bonus(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth) 
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth)
        {
        }
    
        public override void Update(GameTime gameTime)
        {
        }

        public override void RespondToCollision(ICollidable gameObject)
        {
            if (gameObject.ObjType == ObjectType.Player)
            {
                SceneManager.DestroyObject(this);
            }
        }

        public override void Initialize()
        {
        }
    }
}