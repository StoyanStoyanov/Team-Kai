namespace KaiFighterGame.Objects.DynamicObjects.Projectiles
{
    using System;
    using Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Bullet : DynamicObject, ICloneable
    {
        private const string CollisionGroupString = "Bullet";

        public Bullet(Vector2 position, ObjectType objectType, float movementSpeed, int damage, string[] resources = null)
            : base(position, objectType, movementSpeed, damage, resources)
        {
        }      
     
        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void LoadObject(Texture2D texture)
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