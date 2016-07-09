namespace KaiFighterGame.Interfaces 
{
    using Utilities;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// The abstract Dynamic objects factory.
    /// </summary>
    public interface IDynamicObjectFactory
    {
        DynamicObject Create(
            Vector2 position,
            string imageLocation,
            ObjectType objectType,
            Color objColor,
            float scale,
            float rotation,
            float layerDepth,
            float movementSpeed,
            double damage = 0,
            double health = 0,
            int cooldown = 0,
            Vector2 targetDir = default(Vector2)
        );
    }
}