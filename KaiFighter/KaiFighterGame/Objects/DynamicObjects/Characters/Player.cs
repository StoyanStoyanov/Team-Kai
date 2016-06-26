namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Projectiles;
    using Utilities;

    public class Player : DynamicObject
    {
        private const string CollisionGroupString = "Player";

        private Vector2 playerPos;
        private ObjectType characterType;
        private Texture2D playerImage;
        private float playerSpeed;
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public Player(Vector2 position, ObjectType objectType, float speed, int damage, string[] resources = null) 
            : base(position, objectType, speed, damage, resources)
        {
            this.playerPos = position;
            this.characterType = objectType;
            this.playerSpeed = speed;
        }

        public override void LoadObject(Texture2D texture)
        {
            this.playerImage = texture;
        }

        public override void Update(GameTime gameTime)
        {
            // Handles the users input
            this.previousKeyboardState = this.currentKeyboardState;
            this.currentKeyboardState = Keyboard.GetState();

            if (this.currentKeyboardState.IsKeyDown(Keys.A))
            {
                this.playerPos.X -= this.playerSpeed;
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.D))
            {
                this.playerPos.X += this.playerSpeed;
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.W))
            {
                this.playerPos.Y -= this.playerSpeed;
            }

            if (this.currentKeyboardState.IsKeyDown(Keys.S))
            {
                this.playerPos.Y += this.playerSpeed;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.playerImage, this.playerPos, null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);
        }

        public override void RespondToCollision(GameObject gameObject)
        {
            if (gameObject.GetCollisionGroupString() == "Wall")
            {
                if ((this.playerPos.Y + this.Height) >= (gameObject.Position.Y))
                {
                    // shoud check the value, maybe make it const
                    this.position.Y -= 10;
                }
                else if (this.playerPos.Y <= gameObject.Height)
                {
                    this.playerPos.Y += 10;
                }
                else if (this.playerPos.X <= gameObject.Position.X + gameObject.Width)
                {
                    this.playerPos.X += 10;
                }
                else if (this.playerPos.X + this.Width >= gameObject.Position.X)
                {

                    this.playerPos.X -= 10;
                }
            }
            else if (gameObject.GetCollisionGroupString() == "Bullet")
            {
                this.Health -= (gameObject as Bullet).Damage;

            }
            else if (gameObject.GetCollisionGroupString() == "Archer" || gameObject.GetCollisionGroupString() == "Creep")
            {
                this.Health -= (gameObject as DynamicObject).Damage;
            }
            else if (gameObject.GetCollisionGroupString() == "BonusHealth")
            {
                Random rnd = new Random();
                this.Health += rnd.Next(-5, 10);
            }
            else if (gameObject.GetCollisionGroupString() == "Door")
            {
                //TODO: Go to next level
            }
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}