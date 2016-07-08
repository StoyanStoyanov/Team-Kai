namespace KaiFighterGame.Factories
{
    using System;
    using Microsoft.Xna.Framework;
    using Objects.StaticObjects;
    using Utilities;

    /// <summary>
    /// A thread-safe, lazy initialization Singleton implementation of the Static objects factory.
    /// </summary>
    public sealed class StaticObjectFactory : AbstractStaticObjectFactory
    {
        /// <summary>
        /// Initializes an instance of the StaticObjectFactory class the first time
        /// an instance is required, and holds this instance ever since.
        /// </summary>
        private static readonly Lazy<StaticObjectFactory> holder = 
            new Lazy<StaticObjectFactory>(
                () => new StaticObjectFactory());

        /// <summary>
        /// Private constructor, ensures restricted access.
        /// </summary>
        private StaticObjectFactory() { }

        /// <summary>
        /// Provides access point to the single instance of the StaticObjectFactory class.
        /// </summary>
        public static StaticObjectFactory Instance
        {
            get
            {
                return holder.Value;
            }
        }

        /// <summary>
        /// Creates the Static objects in the game.
        /// </summary>
        /// <param name="position">The position of the object.</param>
        /// <param name="objectType">The type of the game object.</param>
        /// <returns>New StaticObject by given object type.</returns>
        public override StaticObject Create(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth)
        {
            switch (objectType)
            {
                case ObjectType.Bonus:
                    return new Bonus(position, imageLocation, objectType, objColor, scale, rotation, layerDepth);
                case ObjectType.Obstacle:
                    return new Obstacle(position, imageLocation, objectType, objColor, scale, rotation, layerDepth);
                case ObjectType.Wall:
                    return new Wall(position, imageLocation, objectType, objColor, scale, rotation, layerDepth);
                default:
                    throw new ArgumentException();
            }
        }
    }
}