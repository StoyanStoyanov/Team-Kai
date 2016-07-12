namespace KaiFighterGame.Objects.StaticObjects
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities;

    public class Obstacle : StaticObject
    {
        public Obstacle(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth)
        {
        }

        public override void LoadContent(Game theGame)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}