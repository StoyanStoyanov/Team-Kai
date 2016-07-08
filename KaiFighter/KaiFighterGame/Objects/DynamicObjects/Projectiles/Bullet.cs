﻿namespace KaiFighterGame.Objects.DynamicObjects.Projectiles
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Utilities;

    public class Bullet : DynamicObject, IKiller
    {
        private const string CollisionGroupString = "Bullet";
        private Vector2 targetDir;
        private bool isPlayerFire;

        public Bullet(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, Vector2 targetDirection)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed)
        {
            this.Damage = damage;
            this.targetDir = targetDirection;
        }

        public double Damage { get; set; }

        // TODO - Change that !!!
        public bool IsPlayerFire
        {
            get
            {
                return this.isPlayerFire;
            }
            set
            {
                this.isPlayerFire = value;
            }
        }

        

        public override void Initialize()
        {
            this.MoveWithoutStop(this.targetDir);
        }

        /// <summary>
        /// If the bullet shound not react when colliding with other bullet and bonus
        /// Also the shooter shoud not be affected
        /// </summary>
        /// <param name="gameObject"></param>
        public override void RespondToCollision(ICollidable gameObject)
        {
            if (this.IsPlayerFire == true)
            {
                if (gameObject.ObjType != ObjectType.Player 
                    && gameObject.ObjType != ObjectType.Bullet
                    && gameObject.ObjType != ObjectType.Bonus)
                {
                    SceneManager.DestroyObject(this);
                }
            }
            else
            {
                if (gameObject.ObjType != ObjectType.Archer
                    && gameObject.ObjType != ObjectType.Bullet
                    && gameObject.ObjType != ObjectType.Bonus)
                {
                    SceneManager.DestroyObject(this);
                }
            }
        }
    }
}