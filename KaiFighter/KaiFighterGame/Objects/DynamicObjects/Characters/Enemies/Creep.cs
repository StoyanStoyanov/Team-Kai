namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using Microsoft.Xna.Framework;

    using Utilities;

    /// <summary>
    /// A creep is a melle type of enemy.
    /// </summary>
    public class Creep : Enemy
    {
        private const int DefaultCreepCooldown = 0;

        public Creep(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health, DefaultCreepCooldown)
        {
        }            
    }
}