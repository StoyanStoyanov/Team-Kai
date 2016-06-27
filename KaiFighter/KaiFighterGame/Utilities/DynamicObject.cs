namespace KaiFighterGame.Utilities
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using System.Diagnostics;
    /// <summary>
    /// Defines a dynamic/moving object in the game. All moving objects should inherit the DynamicObject class.
    /// </summary>
    public abstract class DynamicObject : GameObject, IMovable, IDamageable
    {
        private Vector2 objDirection;
        private float objSpeed;

        public DynamicObject(Vector2 position, string imageLocation, ObjectType objectType, float movementSpeed, int damage) 
            : base(position, imageLocation, objectType)
        {
            this.Damage = damage;
            this.objSpeed = movementSpeed;
            this.objDirection = Vector2.Zero;
        }

        public virtual int Health { get; protected set; }

        public int Damage { get; protected set; }

        public float Speed { get; protected set; }

        public Vector2 Direction 
        {
            get
            {
                return this.objDirection;
            }

            set
            {
                this.objDirection = value;
            }
        }

        public void MoveUp()
        {
            this.objDirection.Y = -1;
        }

        public void MoveDown()
        {
            this.objDirection.Y = 1;
        }

        public void MoveLeft()
        {
            this.objDirection.X = -1;
        }

        public void MoveRight()
        {
            this.objDirection.X = 1;
        }

        public override void Update(GameTime gameTime)
        {
            if (this.objDirection.Y == -1)
            {
                this.PositionY -= this.objSpeed;
            }
            if (this.objDirection.Y == 1)
            {
                this.PositionY += this.objSpeed;
            }
            if (this.objDirection.X == -1)
            {
                this.PositionX -= this.objSpeed;
            }
            if (this.objDirection.X == 1)
            {
                this.PositionX += this.objSpeed;
            }

            this.objDirection.Normalize();
        }

        public virtual void TakeDamage()
        {
            throw new NotImplementedException();
        }
    }
}