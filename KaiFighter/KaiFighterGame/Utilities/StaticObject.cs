namespace KaiFighterGame.Utilities
{
    using Interfaces;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Defines a static object in the game. All static object should inherit the StaticObject class.
    /// </summary>
    public abstract class StaticObject : ICOllidable
    {
        public StaticObject(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth) 
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth)
        {
        }
    }
}