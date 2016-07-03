using System.Runtime.CompilerServices;
using KaiFighterGame.Objects.DynamicObjects.Projectiles;

namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities;

    public class Creep : Character
    {
        private const string CollisionGroupString = "Creep";

        public Creep(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, int damage, int health)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health)
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

        public override void Update(GameTime gameTime)
        {
            ////move
            
            //we can change this to only one direction 
            /*Vector2 test = new Vector2(150, 150);
            this.MoveTowards(test);*/

            Random rnd = new Random();
            int move = rnd.Next(1, 4);
            switch (move)
            {
                case 1: this.MoveUp(); break;
                case 2: this.MoveDown(); break;
                case 3: this.MoveLeft(); break;
                case 4: this.MoveRight(); break;

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