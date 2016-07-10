using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using KaiFighterGame.GlobalConstants;

namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using Microsoft.Xna.Framework;
    using Utilities;

    public class Archer : Enemie
    {


        public Archer(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health, int cooldown)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health, cooldown)
        {
           
        }

        public override void Update(GameTime gameTime)
        {

            this.Shoot(Vector2.Normalize(new Vector2(-1, 0)));

            base.Update(gameTime);
        }
    }
}