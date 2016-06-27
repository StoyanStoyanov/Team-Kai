namespace KaiFighterGame.Objects.StaticObjects
{
    using System;
    using Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Wall : StaticObject
    {
        private const string CollisionGroupString = "Wall";

        public Wall(Vector2 position, string imageLocation, ObjectType objectType)
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