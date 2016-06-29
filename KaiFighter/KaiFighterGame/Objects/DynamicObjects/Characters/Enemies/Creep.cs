namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities;

    public class Creep : Character
    {
        private const string CollisionGroupString = "Creep";

        public Creep(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, int damage, int health)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health)
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