namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GlobalConstants;
    using Utilities;
    using Microsoft.Xna.Framework;


    public abstract class Enemie : Shooter
    {
        private static Random rnd = new Random();
        private int movetox;
        private int movetoy;
        private Vector2 moveto;

        public Enemie(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health, int cooldown)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health, cooldown)
        {
            this.movetox = rnd.Next(100, GameResolution.DefaultWidth - 100);
            this.movetoy = rnd.Next(100, GameResolution.DefaultHeight - 100);
            this.moveto = new Vector2(movetox, movetoy);
        }

        public override void Update(GameTime gameTime)
        {
            //move
            if (this.movetox - (int)this.PositionX < 10 && this.movetoy - (int)this.PositionY < 10)
            {
                this.movetox = rnd.Next(this.Width, GameResolution.DefaultWidth - this.Width);
                this.movetoy = rnd.Next(this.Height, GameResolution.DefaultHeight - this.Height);
                this.moveto = new Vector2(movetox, movetoy);

            }
            this.MoveTowards(this.moveto);


            // update the character object
            base.Update(gameTime);
        }
    }
}
