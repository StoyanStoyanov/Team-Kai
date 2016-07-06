namespace KaiFighterGame.Objects.DynamicObjects.Projectiles
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Utilities;

    public class Bullet : DynamicObject, IKiller
    {
        private const string CollisionGroupString = "Bullet";
        private Vector2 targetDir;
        private  bool isFriendlyFire;

        public Bullet(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, int damage, Vector2 targetDirection)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed)
        {
            this.Damage = damage;
            this.targetDir = targetDirection;
           
        }

        public int Damage { get; set; }

        // TODO - Change that !!!
        public bool IsFriendlyFire
        {
            get
            {
                return this.isFriendlyFire;
            }
            set
            {
                this.isFriendlyFire = value;
            }
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }

        public override void Initialize()
        {
            this.MoveWithoutStop(this.targetDir);
        }

        public override void RespondToCollision(GameObject gameObject)
        {
            if (this.IsFriendlyFire == true)
            {
                if (gameObject.ObjType != ObjectType.Player)
                {
                    this.IsDestroyed = true;
                }
            }else
            {
                if (gameObject.ObjType != ObjectType.Archer)
                {
                    this.IsDestroyed = true;
                }
            }
           
           
        }
    }
}