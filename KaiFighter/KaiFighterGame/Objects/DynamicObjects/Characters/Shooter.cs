namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using System;
    using Factories;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Projectiles;
    using Utilities;
    using GlobalConstants;

    public class Shooter : Character, IRanged
    {
        private int shooterCooldown;
        private int initialCooldown;
        private Vector2 shootDirection;
        private Random bulletRandomizer;

        public Shooter(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, 
                        float rotation, float layerDepth, float speed, double damage, double health, int cooldown) 
                        : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, speed, damage, health)
        {
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

                Bullet someBullet = (Bullet) DynamicObjectFactory.Instance.Create(
                    new Vector2(this.PositionX, this.PositionY),
                    bulletImages[this.bulletRandomizer.Next(0, bulletImages.Length)],
                    ObjectType.Bullet,
                    new Color(this.bulletRandomizer.Next(0, 255),
                                this.bulletRandomizer.Next(0, 255),
                                this.bulletRandomizer.Next(0, 255),
                                this.bulletRandomizer.Next(0, 255)),

                    layerDepth: 1f,
                    rotation: 0f,
                    scale: .3f,
                    damage: this.Damage,
                    cooldown: 8,
                    movementSpeed: 5,
                    targetDir: this.shootDirection
                );
                someBullet.FriendlyFire = (this.ObjType == ObjectType.Player);
                SceneManager.AddObject(someBullet);

                this.shooterCooldown = this.initialCooldown;
            }
        }
    }
}