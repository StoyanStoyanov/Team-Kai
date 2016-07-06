namespace KaiFighterGame.Objects.DynamicObjects.Projectiles
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Utilities;

    public class Bullet : DynamicObject, IKiller
    {
        private const string CollisionGroupString = "Bullet";
        private Vector2 targetDir;

        public Bullet(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, int damage, Vector2 targetDirection)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed)
        {
            this.Damage = damage;
            this.targetDir = targetDirection;
        }

        public int Damage { get; set; }

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
            if (gameObject.ObjType == ObjectType.Wall)
            {
                SceneManager.DestroyObject(this);
            }
        }
    }
}