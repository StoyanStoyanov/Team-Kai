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
            int damage = 0, 
            int health = 0, 
            int cooldown = 0,
            Game theGame = null,
            Vector2 targetDir = default(Vector2));
    }
}