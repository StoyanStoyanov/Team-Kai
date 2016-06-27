namespace KaiFighterGame.Objects.StaticObjects
{
    using System;
    using Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Obstacle : StaticObject
    {
        private const string CollisionGroupString = "Obstacle";

        public Obstacle(Vector2 position, string imageLocation, ObjectType objectType)
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

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}