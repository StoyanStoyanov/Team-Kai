namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Utilities;
    using Projectiles;
    using System.Diagnostics;


    // This is the parent class of the player and all enemies
    public class Character : DynamicObject, IDamageable, IKiller
    {
        public Character(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, int damage, int health) :
            base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed)
        {
            this.Health = health;
            this.Damage = damage;
        }

        public int Health { get; set; }

        public int Damage { get; set; }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }

        public override void RespondToCollision(GameObject gameObject)
        {
            if (gameObject is StaticObject)
            {

                //TODO- Go back
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

            else if (gameObject.GetCollisionGroupString() == "Bullet" && (gameObject as Bullet).IsPlayerFire == true)
            {
                this.Health -= (gameObject as Bullet).Damage;
                Debug.Write(String.Format("Health: {0}, coldie with :{1}", this.Health, gameObject.GetObjectType()));

            }
            else if (gameObject.GetObjectType() == ObjectType.Bonus)
            {

            }
        }

        public override void Initialize()
        {
            // throw new NotImplementedException();
        }
    }
}
