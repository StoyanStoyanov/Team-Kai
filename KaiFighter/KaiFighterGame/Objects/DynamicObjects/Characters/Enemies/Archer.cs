using KaiFighterGame.Objects.DynamicObjects.Projectiles;

namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities;

    public class Archer : Shooter
    {
        private const string CollisionGroupString = "Archer";

        public Archer(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health, int cooldown)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health, cooldown)
        {
        }

    

        public override void Update(GameTime gameTime)
        {
            Vector2 test = new Vector2(150, 150);
            this.MoveTowards(test);

            this.Shoot(Vector2.Normalize(new Vector2(0, -1)));         

            if (this.Health <= 0)
            {
                IsDestroyed = true;

            }

            // update the dynamic object
            base.Update(gameTime);

        }


        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}