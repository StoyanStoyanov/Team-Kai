namespace KaiFighterGame.Utilities
{
    using Interfaces;

    /// <summary>
    /// Defines a static object in the game. All static object should inherit the StaticObject class.
    /// </summary>
    public abstract class StaticObject : GameObject
    {
        public StaticObject(Position position, ObjectType objectType, string resources = null, string size = null, string image = null) 
            : base(position, objectType, resources, size, image)
        {
        }
    }
}