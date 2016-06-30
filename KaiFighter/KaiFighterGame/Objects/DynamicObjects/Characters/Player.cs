namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Projectiles;
    using Utilities;
    using Factories;
    using Interfaces;

    public class Player : Character, IRanged
    {
        private const string CollisionGroupString = "Player";

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private Game currentGame;
        private DynamicObjectFactory bulletFactory;
        private int shooterCooldown;
        private int initialCooldown;
        private Vector2 shootDirection;
        private Random bulletRandomizer;

        public Player(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float speed, int damage, int health, int cooldown, Game theGame) 
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, speed, damage, health)
        {
            this.currentGame = theGame;
            this.bulletFactory = new DynamicObjectFactory();
            this.shooterCooldown = cooldown;
            this.initialCooldown = shooterCooldown;
            this.shootDirection = new Vector2();
            this.bulletRandomizer = new Random();
        }

        public override void Update(GameTime gameTime)
        {
            // Handles the users input
            this.HandleInput(Keyboard.GetState());

            // update the dynamic object
            base.Update(gameTime);
        }

        public override void RespondToCollision(GameObject gameObject)
        {
            if (gameObject.GetCollisionGroupString() == "Wall")
            {
                if ((this.PositionY + this.Height) >= (gameObject.PositionY))
                {
                    // shoud check the value, maybe make it const
                    this.PositionY -= 10;
                }

                if (this.PositionY <= gameObject.Height)
                {
                    this.PositionY += 10;
                }

                if (this.PositionX <= gameObject.PositionX + gameObject.Width)
                {
                    this.PositionX += 10;
                }

                if (this.PositionX + this.Width >= gameObject.PositionX)
                {
                    this.PositionX -= 10;
                }
            }
            else if (gameObject.GetCollisionGroupString() == "Bullet")
            {
                this.Health -= (gameObject as Bullet).Damage;
            }
            else if (gameObject.GetCollisionGroupString() == "Archer" || gameObject.GetCollisionGroupString() == "Creep")
            {
                this.Health -= (gameObject as Character).Damage;
            }
            else if (gameObject.GetCollisionGroupString() == "BonusHealth")
            {
                Random rnd = new Random();
                this.Health += rnd.Next(-5, 10);
            }
            else if (gameObject.GetCollisionGroupString() == "Door")
            {
                // TODO: Go to next level
            }
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }

        private void HandleInput(KeyboardState keyState)
        {
            this.currentKeyboardState = Keyboard.GetState();

            // movement input
            if (this.currentKeyboardState.IsKeyDown(Keys.A))
            {
                this.MoveLeft();
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.D))
            {
                this.MoveRight();
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.W))
            {
                this.MoveUp();
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.S))
            {
                this.MoveDown();
            }

            // shooting input
            if (this.currentKeyboardState.IsKeyDown(Keys.Up))
            {
                this.Shoot(Vector2.Normalize(new Vector2(0, -1)));
            }
            else if (this.currentKeyboardState.IsKeyDown(Keys.Down))
            {
                this.Shoot(Vector2.Normalize(new Vector2(0, 1)));
            }
            else if (this.currentKeyboardState.IsKeyDown(Keys.Left))
            {
                this.Shoot(Vector2.Normalize(new Vector2(-1, 0)));
            }
            else if (this.currentKeyboardState.IsKeyDown(Keys.Right))
            {
                this.Shoot(Vector2.Normalize(new Vector2(1, 0)));
            }

            this.previousKeyboardState = this.currentKeyboardState;
        }

        public void Shoot(Vector2 direction)
        {
            this.shootDirection = direction;

            if (this.shooterCooldown > 0)
            {
                this.shooterCooldown -= 1;
            }
            else
            {
                string[] bulletImages =
                {
                    "Images/Projectiles/0",
                    "Images/Projectiles/1"
                };

                Bullet someBullet = bulletFactory.Create(
                new Vector2(this.PositionX, this.PositionY),
                bulletImages[bulletRandomizer.Next(0, bulletImages.Length)],
                ObjectType.Bullet,
                Color.LimeGreen,
                layerDepth: 1f,
                rotation: 0f,
                scale: .3f,
                damage: 10,
                cooldown: 8,
                movementSpeed: 5,
                theGame: this.currentGame,
                targetDir: this.shootDirection) as Bullet;

                SceneManager.AddObject(someBullet, this.currentGame);

                this.shooterCooldown = this.initialCooldown;
            }  
        }
    }
}