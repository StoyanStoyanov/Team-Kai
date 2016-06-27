namespace KaiFighterGame.Objects.StaticObjects
{
    using System;
    using Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Bounty : StaticObject
    {
        private const string CollisionGroupString = "Bounty";

        public Bounty(Vector2 position, string imageLocation, ObjectType objectType)
            : base(position, imageLocation, objectType)
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

        public override void RespondToCollision(GameObject gameObject)
        {
            this.IsDestroyed = true;
        }
    }
}