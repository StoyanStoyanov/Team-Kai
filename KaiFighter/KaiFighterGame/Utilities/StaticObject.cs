namespace KaiFighterGame.Utilities
{
    using Interfaces;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Defines a static object in the game. All static object should inherit the StaticObject class.
    /// </summary>
    public abstract class StaticObject : GameObject
    {
        public StaticObject(Vector2 position, string imageLocation, ObjectType objectType) 
            : base(position, imageLocation, objectType)
        {
        }
    }
}