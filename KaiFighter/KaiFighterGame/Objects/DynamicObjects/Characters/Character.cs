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
            //throw new NotImplementedException();
        }

        public override void RespondToCollision(GameObject gameObject)
        {
            if (gameObject is StaticObject)
            {
                if (gameObject.ObjType == ObjectType.Wall)
                {
                    this.PositionX = this.PreviousPositionX;
                    this.PositionY = this.PreviousPositionY;
                }
            }

            else if (gameObject.ObjType == ObjectType.Bullet && (gameObject as Bullet).IsPlayerFire)
            {
                this.Health -= (gameObject as Bullet).Damage;
                //Debug.Write(String.Format("Health: {0}, coldie with :{1}", this.Health, gameObject.GetObjectType()));
            }
            
        }

        public override void Update(GameTime gameTime)
        {
            if (this.Health <= 0)
            {
                SceneManager.DestroyObject(this);
            }

            base.Update(gameTime);
        }

        public override void Initialize()
        {
            // throw new NotImplementedException();
        }
    }
}
