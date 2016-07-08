﻿namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;
    using Utilities;

    /// <summary>
    /// All objects which can collide will implement this interface.
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// How the object responds to a collision.
        /// </summary>
        void RespondToCollision(ICollidable gameObject);
        Rectangle BoundingBox { get; }
        ObjectType ObjType { get; }

    }
}