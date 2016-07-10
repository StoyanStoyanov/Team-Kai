namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Utilities;

    public class Boss : Wizard
    {

        private const int normalFireCooldownTime = 60;
        private int fireTime = normalFireCooldownTime;


        public Boss(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale,
    float rotation, float layerDepth, float movementSpeed, double damage, double health)
            : base(
                position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage,
                health)
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

                this.fireTime = normalFireCooldownTime;
            }

            // update the dynamic object
            base.Update(gameTime);
        }
    }
}
