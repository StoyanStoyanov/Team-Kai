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

        public DynamicObject(Vector2 position, ObjectType objectType, float movementSpeed, string[] resources = null) 
            : base(position, objectType, resources)
        {
        }

        public virtual int Health { get; protected set; }

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