namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Utilities;

    // This is the parent class of the player and all enemies
    public class Character : DynamicObject, IDamageable, IKiller
    {
        public Character(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, int damage, int health) : 
            base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed)
        {
            this.Health = health;
            this.Damage = damage;
        }

        public int Health { get; set; }

        public int Damage { get; set; }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            // throw new NotImplementedException();
        }
    }
}
