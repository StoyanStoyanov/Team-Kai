namespace KaiFighterGame.Factories
{
    using System;
    using Microsoft.Xna.Framework;
    using Objects.StaticObjects;
    using Utilities;

    /// <summary>
    /// The Static objects factory.
    /// </summary>
    public class StaticObjectFactory : AbstractStaticObjectFactory
    {
        /// <summary>
        /// Creates the Static objects in the game.
        /// </summary>
        /// <param name="position">The position of the object.</param>
        /// <param name="objectType">The type of the game object.</param>
        /// <returns></returns>
        public override StaticObject Create(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth)
        {
            switch (objectType)
            {
                case ObjectType.Bonus:
                    return new Bonus(position, imageLocation, objectType, objColor, scale, rotation, layerDepth);
                case ObjectType.Bounty:
                    return new Bounty(position, imageLocation, objectType, objColor, scale, rotation, layerDepth);
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