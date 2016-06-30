﻿namespace KaiFighterGame.Objects.StaticObjects
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities;

    public class Wall : StaticObject
    {
        private const string CollisionGroupString = "Wall";

        public Wall(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void LoadContent(Game theGame)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}