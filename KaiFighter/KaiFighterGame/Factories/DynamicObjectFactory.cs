namespace KaiFighterGame.Factories
{
    using System;
    using Microsoft.Xna.Framework;
    using Objects.DynamicObjects.Characters;
    using Objects.DynamicObjects.Characters.Enemies;
    using Objects.DynamicObjects.Projectiles;
    using Utilities;

    /// <summary>
    /// A thread-safe, lazy initialization Singleton implementation of the Dynamic objects factory.
    /// </summary>
    public sealed class DynamicObjectFactory : AbstractDynamicObjectFactory
    {
        /// <summary>
        /// Initializes an instance of the DynamicObjectFactory class the first time
        /// an instance is required, and holds this instance ever since.
        /// </summary>
        private static readonly Lazy<DynamicObjectFactory> holder =
            new Lazy<DynamicObjectFactory>(
                () => new DynamicObjectFactory());

        /// <summary>
        /// Private constructor, ensures restricted access.
        /// </summary>
        private DynamicObjectFactory() { }

        /// <summary>
        /// Provides access to the only instance of the DynamicObjectFactory class.
        /// </summary>
        public static DynamicObjectFactory Instance
        {
            get
            {
                return holder.Value;
            }
        }

        /// <summary>
        /// Creates the Dynamic objects in the game.
        /// </summary>
        /// <param name="position">The position of the object.</param>
        /// <param name="objectType">The type of the game object.</param>
        /// <param name="movementSpeed">The movement speed of the Dynamic object.</param>
        /// <param name="damage">The damage of the Dynamic object</param>
        /// <returns>New DynamicObject by given object type.</returns>
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