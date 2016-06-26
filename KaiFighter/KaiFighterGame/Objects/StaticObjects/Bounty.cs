namespace KaiFighterGame.Objects.StaticObjects
{
    using System;
    using Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Bounty : StaticObject
    {
        private const string CollisionGroupString = "Bounty";

        public Bounty(Vector2 position, ObjectType objectType, string[] resources = null)
            : base(position, objectType, resources)
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

        public override void RespondToCollision(GameObject gameObject)
        {
            this.IsDestroyed = true;
        }
    }
}