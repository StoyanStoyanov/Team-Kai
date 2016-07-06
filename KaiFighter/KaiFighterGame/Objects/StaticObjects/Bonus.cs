namespace KaiFighterGame.Objects.StaticObjects
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities;

    public class Bonus : StaticObject
    {
        private const string CollisionGroupString = "Bonus";

        public Bonus(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth) 
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth)
        {
        }

    
        public override void Update(GameTime gameTime)
        {
           // throw new NotImplementedException();
        }

        public override void RespondToCollision(GameObject gameObject)
        {

            if (gameObject.GetObjectType() == ObjectType.Player)
            {
                this.IsDestroyed = true;
            }
          
        }

        public override void Initialize()
        {
           // throw new NotImplementedException();
        }
    }
}