namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Archer : DynamicObject
    {
        private const string CollisionGroupString = "Archer";

        public Archer(Vector2 position, string imageLocation, ObjectType objectType, float movementSpeed, int damage)
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

        public override void RespondToCollision(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}