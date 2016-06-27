namespace KaiFighterGame.Objects.DynamicObjects.Projectiles
{
    using System;
    using Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Bullet : DynamicObject, ICloneable
    {
        private const string CollisionGroupString = "Bullet";

        public Bullet(Vector2 position, string imageLocation, ObjectType objectType, float movementSpeed, int damage)
            : base(position, imageLocation, objectType, movementSpeed, damage)
        {
        }      
     
        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void LoadContent(Game theGame)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }

        public override void RespondToCollision(GameObject gameObject)
        {
            this.IsDestroyed = true;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}