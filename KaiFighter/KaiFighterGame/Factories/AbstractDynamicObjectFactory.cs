namespace KaiFighterGame.Factories
{
    using Microsoft.Xna.Framework;
    using Utilities;

    public abstract class AbstractDynamicObjectFactory
    {
        public abstract DynamicObject Create(
            Vector2 position,
            string imageLocation,
            ObjectType objectType,
            Color? objColor,
            float scale,
            float rotation,
            float layerDepth,
            float movementSpeed,
            double damage = 0,
            double health = 0,
            int cooldown = 0,
            Vector2 targetDir = default(Vector2));
    }
}