using KaiFighterGame.Global_Constants;

namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using System;
    using Factories;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Projectiles;
    using Utilities;

    // this is the base class for all ranged characters
    public class Shooter : Character, IRanged
    {
        private DynamicObjectFactory bulletFactory;
        private int shooterCooldown;
        private int initialCooldown;
        private Vector2 shootDirection;
        private Random bulletRandomizer;

        public Shooter(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float speed, double damage, double health, int cooldown) 
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, speed, damage, health)
        {
            this.bulletFactory = new DynamicObjectFactory();
            this.shooterCooldown = cooldown;
            this.initialCooldown = this.shooterCooldown;
            this.shootDirection = new Vector2();
            this.bulletRandomizer = new Random();
        }

        public virtual void Shoot(Vector2 direction)
        {
            this.shootDirection = direction;

            if (this.shooterCooldown > 0)
            {
                this.shooterCooldown -= 1;
            }
            else
            {
                string[] bulletImages =
                {
                    ImageAddresses.Projectile0Image,
                    ImageAddresses.Projectile1Image
                };

                Bullet someBullet = this.bulletFactory.Create(
                new Vector2(this.PositionX, this.PositionY),
                bulletImages[this.bulletRandomizer.Next(0, bulletImages.Length)],
                ObjectType.Bullet,
                Color.LimeGreen,
                layerDepth: 1f,
                rotation: 0f,
                scale: .3f,
                damage: this.Damage,
                cooldown: 8,
                movementSpeed: 5,
                targetDir: this.shootDirection
               ) as Bullet;
                someBullet.IsPlayerFire = (this.ObjType == ObjectType.Player ? true : false);
                SceneManager.AddObject(someBullet, EntryPoint.TheGame);

                this.shooterCooldown = this.initialCooldown;
            }
        }
    }
}
