namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;

    using Utilities;

    /// <summary>
    /// All objects which can collide must implement this interface.
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// The bounding box of every ICollidable object.
        /// </summary>
        Rectangle BoundingBox { get; }

        /// <summary>
        /// The object type of the object.
        /// </summary>
        ObjectType ObjType { get; }

        /// <summary>
        /// How the object responds to a collision.
        /// </summary>
        void RespondToCollision(ICollidable gameObject);
    }
}