namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using Microsoft.Xna.Framework;

    using Utilities;

    public class Boss : Wizard
    {
        private const int NormalFireCooldownTime = 60;
        private int fireTime = NormalFireCooldownTime;

        public Boss(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage,  health)
        {
        }

        public override void Update(GameTime gameTime)
        {
            this.fireTime--;

            if (this.fireTime <= 0)
            {
                this.Shoot(Vector2.Normalize(new Vector2(-2, 0)));
                this.Shoot(Vector2.Normalize(new Vector2(0, 2)));
                this.Shoot(Vector2.Normalize(new Vector2(2, 0)));
                this.Shoot(Vector2.Normalize(new Vector2(0, -2)));

                this.fireTime = NormalFireCooldownTime;
            }

            base.Update(gameTime);
        }
    }
}