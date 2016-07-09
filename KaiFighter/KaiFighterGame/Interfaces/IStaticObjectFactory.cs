namespace KaiFighterGame.Interfaces 
{
    using Utilities;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// The abstract Static objects factory.
    /// </summary>
    public interface IStaticObjectFactory
    {
        StaticObject Create(
            Vector2 position, 
            string imageLocation, 
            ObjectType objectType, 
            Color objColor, 
            float scale, 
            float rotation, 
            float layerDepth
        );
    }
}