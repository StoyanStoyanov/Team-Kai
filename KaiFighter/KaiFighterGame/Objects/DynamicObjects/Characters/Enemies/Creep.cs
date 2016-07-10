namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Microsoft.Xna.Framework;
    using Utilities;
    using GlobalConstants;


    public class Creep : Enemie
    {
        public Creep(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health, 0)
        {
        }     
        
    }
}