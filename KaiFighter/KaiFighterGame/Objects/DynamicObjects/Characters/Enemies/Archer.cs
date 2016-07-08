namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using Microsoft.Xna.Framework;
    using Utilities;

    public class Archer : Shooter
    {
        public Archer(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health, int cooldown)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health, cooldown)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 test = new Vector2(150, 150);
            this.MoveTowards(test);

            this.Shoot(Vector2.Normalize(new Vector2(0, -1)));

            // update the character object
            base.Update(gameTime);
        }
    }
}