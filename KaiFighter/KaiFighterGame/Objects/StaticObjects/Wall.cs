namespace KaiFighterGame.Objects.StaticObjects
{
    using Microsoft.Xna.Framework;
    using Utilities;

    public class Wall : StaticObject
    {
        public Wall(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth)
        {
        }
    
        public override void Initialize()
        {
            // throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }
    }
}