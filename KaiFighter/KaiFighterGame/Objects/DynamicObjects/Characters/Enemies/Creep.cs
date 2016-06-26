namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Creep: DynamicObject
    {
        private const string CollisionGroupString = "Creep";

        public Creep(Vector2 position, ObjectType objectType, float movementSpeed, int damage, string[] resources = null)
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

        public override void RespondToCollision(GameObject gameObject)
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