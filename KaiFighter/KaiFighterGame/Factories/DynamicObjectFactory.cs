namespace KaiFighterGame.Factories
{
    using System;
    using Microsoft.Xna.Framework;
    using Objects.DynamicObjects.Characters;
    using Objects.DynamicObjects.Characters.Enemies;
    using Objects.DynamicObjects.Projectiles;
    using Utilities;

    /// <summary>
    /// The Dynamic objects factory.
    /// </summary>
    public class DynamicObjectFactory : AbstractDynamicObjectFactory
    {
        /// <summary>
        /// Creates the Dynamic objects in the game.
        /// </summary>
        /// <param name="position">The position of the object.</param>
        /// <param name="objectType">The type of the game object.</param>
        /// <param name="movementSpeed">The movement speed of the Dynamic object.</param>
        /// <param name="damage">The damage of the Dynamic object</param>
        /// <returns></returns>
        public override DynamicObject Create(
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
            Vector2 targetDir = default(Vector2))
        {
            switch (objectType)
            {
                case ObjectType.Player:
                    return new Player(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health, cooldown);
                case ObjectType.Archer:
                    return new Archer(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health, cooldown);
                case ObjectType.Creep:
                    return new Creep(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health);
                case ObjectType.Wizard:
                    return new Wizard(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health);
                case ObjectType.Bullet:
                    return new Bullet(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, targetDir);
                default:
                    throw new ArgumentException();
            }
        }
    }
}