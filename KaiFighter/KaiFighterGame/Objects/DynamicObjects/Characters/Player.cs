namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Projectiles;
    using Utilities;
    using Interfaces;

    public class Player : Shooter
    {
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private int score;

        public Player(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float speed, double damage, double health, int cooldown)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, speed, damage, health, cooldown)
        {
            this.Score = 0;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                this.score = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            // Handles the users inputw
            this.HandleInput(Keyboard.GetState());

            // update the dynamic object
            base.Update(gameTime);

            if (this.Health <= 0)
            {
                SceneManager.DestroyObject(this);
            }
        }

        public override void RespondToCollision(ICollidable gameObject)
        {
            if (gameObject.ObjType == ObjectType.Wall)
            {
                this.PositionX = this.PreviousPositionX;
                this.PositionY = this.PreviousPositionY;
            }
            else if (gameObject.ObjType == ObjectType.Bullet 
                 && ((Bullet) gameObject).FriendlyFire == false)
            {
                this.Health -= ((Bullet)gameObject).Damage;
            }
            else if (gameObject.ObjType == ObjectType.Archer
                  || gameObject.ObjType == ObjectType.Creep
                  || gameObject.ObjType == ObjectType.Wizard)
            {
                this.Health -= ((Character)gameObject).Damage / 10 ;
                this.PositionX = this.PreviousPositionX;
                this.PositionY = this.PreviousPositionY;
            }
            else if (gameObject.ObjType == ObjectType.Bonus)
            {
                Random rnd = new Random();
                this.Health += rnd.Next(-5, 10);
                this.Damage += rnd.Next(2, 10);
                this.Score += rnd.Next(10, 20);
                
            }
            else if (gameObject.ObjType == ObjectType.Door)
            {
                // TODO- NEXT LEVEL
            }
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
    }
}