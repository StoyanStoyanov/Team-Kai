namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Microsoft.Xna.Framework;

    using GlobalConstants;
    using Utilities;

    /// <summary>
    /// Defines an enemy in the game.
    /// </summary>
    public abstract class Enemy : Shooter
    {
        private const int DefaultDistanceOfWallForFirstMove = 200;
        private static Random rnd = new Random();
        private int movetox;
        private int movetoy;
        private Vector2 moveto;

        public Enemy(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health, int cooldown)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health, cooldown)
        {
            this.movetox = rnd.Next(DefaultDistanceOfWallForFirstMove, GameResolution.DefaultWidth - DefaultDistanceOfWallForFirstMove);
            this.movetoy = rnd.Next(DefaultDistanceOfWallForFirstMove, GameResolution.DefaultHeight - DefaultDistanceOfWallForFirstMove);

            this.moveto = new Vector2(this.movetox, this.movetoy);
        }

        public override void Update(GameTime gameTime)
        {
            if (this.movetox - (int)this.PositionX < 10 && this.movetoy - (int)this.PositionY < 10)
            {
                this.movetox = rnd.Next(this.Width, GameResolution.DefaultWidth - this.Width);
                this.movetoy = rnd.Next(this.Height, GameResolution.DefaultHeight - this.Height);

                this.moveto = new Vector2(this.movetox, this.movetoy);
            }

            this.MoveTowards(this.moveto);

            base.Update(gameTime);
        }
    }
}