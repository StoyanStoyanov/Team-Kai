namespace KaiFighterGame.Factories
{
    using Utilities;
    using Microsoft.Xna.Framework;

    public abstract class AbstractStaticObjectFactory
    {
        public abstract StaticObject Create(Vector2 position, ObjectType objectType);
    }
}