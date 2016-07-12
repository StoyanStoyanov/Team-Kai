namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using System;
    using System.IO;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework;

    using Interfaces;
    using Utilities;
    using Projectiles;
    using GlobalConstants;
    using Factories;
    using StaticObjects;

    /// <summary>
    /// The parent class of the player and all enemies.
    /// </summary>
    public abstract class Character : DynamicObject, IDamageable, IKiller
    {
        private Random colorRandomizer;
        private SoundEffect deathEffect;

        public Character(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed)
        {
            this.Health = health;
            this.Damage = damage;
            this.colorRandomizer = new Random();
            this.OnDead += this.DeathActions;
        }

        public delegate void DeathAction();

        public event DeathAction OnDead;

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
            else if (gameObject.ObjType == ObjectType.Bullet && ((Bullet)gameObject).FriendlyFire)
            {
                this.ObjectColor = new Color(this.colorRandomizer.Next(0, 255), this.colorRandomizer.Next(0, 255), this.colorRandomizer.Next(0, 255), 255);
                this.Health -= ((Bullet)gameObject).Damage;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (this.Health <= 0)
            {
                this.OnDead?.Invoke();
            }

            base.Update(gameTime);
        }

        public override void LoadContent(Game theGame)
        {
            this.deathEffect = theGame.Content.Load<SoundEffect>(AudioAddresses.ExplosionSound);

            base.LoadContent(theGame);  
        }

        public override void UnloadContent()
        {
            this.OnDead = null;

            this.deathEffect.Dispose();

            base.UnloadContent();   
        }

        protected virtual void DeathActions()
        {
            SceneManager.DestroyObject(this);

            var someBonus = (Bonus)StaticObjectFactory.Instance.Create(
                new Vector2(this.PositionX, this.PositionY),
                ImageAddresses.BonusImage,
                ObjectType.Bonus,
                Color.Red,
                scale: .2f,
                rotation: 0f,
                layerDepth: RenderLayers.StaticsLayer);
            SceneManager.AddObject(someBonus);

            this.deathEffect.Play(.3f, 0f, 0f);

            SceneManager.DestroyObject(this);
            this.SaveToScoreBoard();
        }

        private void SaveToScoreBoard()
        {
            int deathsCount = 0;
            int fileScore = 0;
            int killsCount = 0;

            using (var reader = new StreamReader(File.Open("../../SavedGame.txt", FileMode.OpenOrCreate)))
            {
                string deaths = reader.ReadLine();

                if (!string.IsNullOrEmpty(deaths))
                {
                    deathsCount = int.Parse(deaths);
                }

                string score = reader.ReadLine();

                if (!string.IsNullOrEmpty(score))
                {
                    fileScore = int.Parse(score);
                }

                string kills = reader.ReadLine();

                if (!string.IsNullOrEmpty(kills))
                {
                    killsCount = int.Parse(kills);
                }

                reader.Close();
            }

            using (var writer = new StreamWriter("../../SavedGame.txt", false))
            {
                writer.WriteLine(deathsCount);

                writer.WriteLine(fileScore);

                writer.WriteLine(++killsCount);

                writer.Close();
            }
        }
    }
}