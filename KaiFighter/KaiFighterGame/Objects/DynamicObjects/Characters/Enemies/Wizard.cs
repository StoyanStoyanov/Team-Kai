using System.Runtime.CompilerServices;
using KaiFighterGame.Objects.DynamicObjects.Projectiles;

namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities;

    public class Wizard : Character
    {
        private const string CollisionGroupString = "Wizard";

        public Wizard(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health)
        {

        }

        public override void Update(GameTime gameTime)
        {
            ////move

            //we can change this to only one direction 

            Random rnd = new Random();
            int move = rnd.Next(1, 3);
            switch (move)
            {
                case 1: this.MoveUp(); break;
                case 2: this.MoveDown(); break;
                case 3: this.MoveLeft(); break;
                case 4: this.MoveRight(); break;

            }

            ////TODO Hit like creep + magic 1/10000 updates 
            

            // update the dynamic object
            base.Update(gameTime);

            if (this.Health <= 0)
            {
                IsDestroyed = true;
            }
        }

        public override void RespondToCollision(GameObject gameObject)
        {

            if (gameObject.ObjType == ObjectType.Wall)
            {

                this.PositionX = this.PreviousPositionX;
                this.PositionY = this.PreviousPositionY;

            }
            else if (gameObject.GetCollisionGroupString() == "Bullet" && (gameObject as Bullet).IsPlayerFire)
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