namespace KaiFighterGame.Factories
{
    using Utilities;
    using Microsoft.Xna.Framework;

    public abstract class AbstractDynamicObjectFactory
    {
        public abstract DynamicObject Create(Vector2 position, ObjectType objectType, float movementSpeed, int damage = 0);
    }
}