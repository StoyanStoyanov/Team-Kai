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

        public Archer(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, int damage, int health, int cooldown, Game theGame)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health, cooldown,theGame)
        {
        }

        /*public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void LoadContent(Game theGame)
        {
            throw new NotImplementedException();
        }*/

        public override void Update(GameTime gameTime)
        {
            Vector2 test = new Vector2(150, 150);
            this.MoveTowards(test);

            //TODO: decide how we will shoot - random direction or directly to the player ! 

            this.Shoot(Vector2.Normalize(new Vector2(0, -1)));

            // update the dynamic object
            base.Update(gameTime);
        }

        public override void RespondToCollision(GameObject gameObject)
        {
            if (gameObject.GetCollisionGroupString() == "Wall")
            {
                if ((this.PositionY + this.Height) >= (gameObject.PositionY))
                {
                    this.PositionY -= 10;
                }

                if (this.PositionY <= gameObject.Height)
                {
                    this.PositionY += 10;
                }

                if (this.PositionX <= gameObject.PositionX + gameObject.Width)
                {
                    this.PositionX += 10;
                }

                if (this.PositionX + this.Width >= gameObject.PositionX)
                {
                    this.PositionX -= 10;
                }
            }
            else if (gameObject.GetCollisionGroupString() == "Bullet")
            {
                this.Health -= (gameObject as Bullet).Damage;
            }
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}