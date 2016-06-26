namespace KaiFighterGame.Utilities
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Defines a dynamic/moving object in the game. All moving objects should inherit the DynamicObject class.
    /// </summary>
    public abstract class DynamicObject : GameObject, IMovable, IDamageable
    {
        private Vector2 objDirection = Vector2.Zero;
        private int power;
        public DynamicObject(Vector2 position, ObjectType objectType, float movementSpeed, int power, string[] resources = null) 
            : base(position, objectType, resources)
        {
            this.Power = power;
        }

        public virtual int Health { get; protected set; }

        public int Power
        {
            get
            {
                return this.power;
            }
            set
            {
                this.power = value;
            }
        }
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

        public void Move()
        {
            throw new NotImplementedException();
        }

        public virtual void TakeDamage()
        {
            throw new NotImplementedException();
        }
    }
}