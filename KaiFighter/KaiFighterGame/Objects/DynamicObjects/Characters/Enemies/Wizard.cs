namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using Microsoft.Xna.Framework;
    using Utilities;

    public class Wizard : Enemy
    {
        private const int MagicCooldownTime = 400;
        private const int DefaultWizardCooldown = 0;

        private readonly Vector2[] MagicShotDirections =
        {
            new Vector2(-2, 0),
            new Vector2(-2, 1),
            new Vector2(-2, 2),
            new Vector2(-1, 2),
            new Vector2(-0, 2),
            new Vector2(1, 2),
            new Vector2(2, 2),
            new Vector2(2, 1),
            new Vector2(2, 0),
            new Vector2(2, -1),
            new Vector2(2, -2),
            new Vector2(1, -2),
            new Vector2(0, -2),
            new Vector2(-1, -2),
            new Vector2(-2, -2),
            new Vector2(-2, -1),
        };

        private int magicTime = MagicCooldownTime;

        public Wizard(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale,
                         float rotation, float layerDepth, float movementSpeed, double damage, double health)
                         : base(position, imageLocation, objectType, objColor, scale,
                               rotation, layerDepth, movementSpeed, damage, health, DefaultWizardCooldown)
        {

        }

        public override void Update(GameTime gameTime)
        {
            this.magicTime--;
            if (this.magicTime <= 0)
            {
                foreach (var vector in MagicShotDirections)
                {
                    this.Shoot(Vector2.Normalize(vector));
                }

                this.magicTime = MagicCooldownTime;
            }

            base.Update(gameTime);
        }
    }
}