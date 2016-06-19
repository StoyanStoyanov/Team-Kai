namespace KaiFighterGame.Utilities
{
    using System;
    using Interfaces;

    /// <summary>
    /// Defines a dynamic/moving object in the game. All moving objects should inherit the DynamicObject class.
    /// </summary>
    public abstract class DynamicObject : GameObject, IMovable, IDamagable
    {
        public DynamicObject(Position position, ObjectType objectType, string resources = null, string size = null, string image = null) 
            : base(position, objectType, resources, size, image)
        {
        }

        public virtual int Health { get; protected set; }

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