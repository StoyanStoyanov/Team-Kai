namespace KaiFighterGame.Factories
{
    using System;
    using Utilities;
    using Objects.StaticObjects;
    using Microsoft.Xna.Framework;

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
        public override StaticObject Create(Vector2 position, string imageLocation, ObjectType objectType)
        {
            switch (objectType)
            {
                case ObjectType.Bonus:
                    return new Bonus(position, imageLocation, objectType);
                case ObjectType.Bounty:
                    return new Bounty(position, imageLocation, objectType);
                case ObjectType.Obstacle:
                    return new Obstacle(position, imageLocation, objectType);
                case ObjectType.Wall:
                    return new Wall(position, imageLocation, objectType);
                default:
                    throw new ArgumentException();
            }
        }
    }
}