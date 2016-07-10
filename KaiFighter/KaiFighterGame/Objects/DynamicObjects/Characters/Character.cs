namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Utilities;
    using Projectiles;
    using GlobalConstants;
    using Factories;
    using StaticObjects;


    /// <summary>
    /// The parent class of the player and all enemies.
    /// </summary>
    public class Character : DynamicObject, IDamageable, IKiller
    {
        public Character(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed)
        {
            this.Health = health;
            this.Damage = damage;
        }

        public double Health { get; set; }

        public double Damage { get; set; }

       
        public override void RespondToCollision(ICollidable gameObject)
        {
            if (gameObject is StaticObject)
            {
                if (gameObject.ObjType == ObjectType.Wall)
                {
                    this.PositionX = this.PreviousPositionX;
                    this.PositionY = this.PreviousPositionY;
                }
            }

            else if (gameObject.ObjType == ObjectType.Bullet && ((Bullet) gameObject).FriendlyFire)
            {
                this.Health -= ((Bullet)gameObject).Damage;
                //Debug.Write(String.Format("Health: {0}, coldie with :{1}", this.Health, gameObject.GetObjectType()));
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (this.Health <= 0)
            {
                SceneManager.DestroyObject(this);

                var someBonus = (Bonus)StaticObjectFactory.Instance.Create(
                    new Vector2(this.PositionX, this.PositionY),
                    ImageAddresses.BonusImage,
                    ObjectType.Bonus,
                    Color.Red,
                    scale: .2f,
                    rotation: 0f,
                    layerDepth: 1f
                );
                SceneManager.AddObject(someBonus);
                SceneManager.DestroyObject(this);
            }

            base.Update(gameTime);
        }

        public override void Initialize()
        {
            // throw new NotImplementedException();
        }
    }
}