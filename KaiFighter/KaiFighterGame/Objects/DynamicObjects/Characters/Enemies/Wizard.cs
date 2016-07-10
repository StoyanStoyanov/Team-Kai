namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Microsoft.Xna.Framework;
    using Utilities;
    using GlobalConstants;

    public class Wizard : Enemie
    {
        public Wizard(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale,
            float rotation, float layerDepth, float movementSpeed, double damage, double health)
            : base(
                position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage,
                health, 0)
        {
        }

        public override void Update(GameTime gameTime)
        {

            ////TODO Hit like creep + magic 1/10000 updates 

            // update the dynamic object
            base.Update(gameTime);
        }
    }
}