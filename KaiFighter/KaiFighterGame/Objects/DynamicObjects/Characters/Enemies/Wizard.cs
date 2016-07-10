namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Microsoft.Xna.Framework;
    using Utilities;
    using GlobalConstants;

    public class Wizard : Enemie
    {
        private const int magicCooldownTime = 400;
        private int magicTime = magicCooldownTime;

        public Wizard(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale,
            float rotation, float layerDepth, float movementSpeed, double damage, double health)
            : base(
                position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage,
                health, 0)
        {
        }

        public override void Update(GameTime gameTime)
        {
            this.magicTime--;
            if (this.magicTime <= 0)
            {
                this.Shoot(Vector2.Normalize(new Vector2(-2, 0)));
                this.Shoot(Vector2.Normalize(new Vector2(-2, 1)));
                this.Shoot(Vector2.Normalize(new Vector2(-2, 2)));
                this.Shoot(Vector2.Normalize(new Vector2(-1, 2)));
                this.Shoot(Vector2.Normalize(new Vector2(-0, 2)));
                this.Shoot(Vector2.Normalize(new Vector2(1, 2)));
                this.Shoot(Vector2.Normalize(new Vector2(2, 2)));
                this.Shoot(Vector2.Normalize(new Vector2(2, 1)));
                this.Shoot(Vector2.Normalize(new Vector2(2, 0)));
                this.Shoot(Vector2.Normalize(new Vector2(2, -1)));
                this.Shoot(Vector2.Normalize(new Vector2(2, -2)));
                this.Shoot(Vector2.Normalize(new Vector2(1, -2)));
                this.Shoot(Vector2.Normalize(new Vector2(0, -2)));
                this.Shoot(Vector2.Normalize(new Vector2(-1, -2)));
                this.Shoot(Vector2.Normalize(new Vector2(-2, -2)));
                this.Shoot(Vector2.Normalize(new Vector2(-2, -1)));

                this.magicTime = magicCooldownTime;
            }

            // update the dynamic object
            base.Update(gameTime);
        }
    }
}