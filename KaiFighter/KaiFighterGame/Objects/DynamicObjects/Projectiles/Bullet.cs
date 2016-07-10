namespace KaiFighterGame.Objects.DynamicObjects.Projectiles
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Utilities;

    public class Bullet : DynamicObject, IKiller
    {
        private Vector2 targetDir;

        public Bullet(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, Vector2 targetDirection)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed)
        {
            this.Damage = damage;
            this.targetDir = targetDirection;
        }

        public double Damage { get; set; }

        public bool FriendlyFire { get; set; }

        public override void Initialize()
        {
            this.MoveWithoutStop(this.targetDir);
        }

        /// <summary>
        /// If the bullet should not react when colliding with other bullet and bonus
        /// Also the shooter should not be affected
        /// </summary>
        /// <param name="gameObject"></param>
        public override void RespondToCollision(ICollidable gameObject)
        {
            if (this.FriendlyFire == true)
            {
                if (gameObject.ObjType != ObjectType.Player 
                 && gameObject.ObjType != ObjectType.Bullet
                 && gameObject.ObjType != ObjectType.Bonus)
                {
                    SceneManager.DestroyObject(this);
                }
            }
            else
            {
                if (gameObject.ObjType != ObjectType.Archer
                 && gameObject.ObjType != ObjectType.Creep          //bullet can move over enemies  
                 && gameObject.ObjType != ObjectType.Wizard
                 && gameObject.ObjType != ObjectType.Boss
                 && gameObject.ObjType != ObjectType.Bullet
                 && gameObject.ObjType != ObjectType.Bonus)
                {
                   SceneManager.DestroyObject(this);
                }
            }
        }
    }
}