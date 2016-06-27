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

        private ObjectType characterType;
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public Player(Vector2 position, string imageLocation, ObjectType objectType, float speed, int damage) 
            : base(position, imageLocation, objectType, speed, damage)
        {
            this.characterType = objectType;
        }

        public override void Update(GameTime gameTime)
        {
            //Handles the users input
            this.HandleInput(Keyboard.GetState());

            // update the dynamic object
            base.Update(gameTime);
        }

        //public override void RespondToCollision(GameObject gameObject)
        //{
        //    if (gameObject.GetCollisionGroupString() == "Wall")
        //    {
        //        if ((this.Position.Y + this.Height) >= (gameObject.Position.Y))
        //        {
        //            // shoud check the value, maybe make it const
        //            this.Position.Y -= 10;
        //        }
        //        if (this.playerPos.Y <= gameObject.Height)
        //        {
        //            this.playerPos.Y += 10;
        //        }
        //        if (this.playerPos.X <= gameObject.Position.X + gameObject.Width)
        //        {
        //            this.playerPos.X += 10;
        //        }
        //        if (this.playerPos.X + this.Width >= gameObject.Position.X)
        //        {
        //            this.playerPos.X -= 10;
        //        }
        //    }
        //    else if (gameObject.GetCollisionGroupString() == "Bullet")
        //    {
        //        this.Health -= (gameObject as Bullet).Damage;

        //    }
        //    else if (gameObject.GetCollisionGroupString() == "Archer" || gameObject.GetCollisionGroupString() == "Creep")
        //    {
        //        this.Health -= (gameObject as DynamicObject).Damage;
        //    }
        //    else if (gameObject.GetCollisionGroupString() == "BonusHealth")
        //    {
        //        Random rnd = new Random();
        //        this.Health += rnd.Next(-5, 10);
        //    }
        //    else if (gameObject.GetCollisionGroupString() == "Door")
        //    {
        //        //TODO: Go to next level
        //    }
        //}

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }

        private void HandleInput(KeyboardState keyState)
        {
            this.previousKeyboardState = this.currentKeyboardState;
            this.currentKeyboardState = Keyboard.GetState();

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
        }
    }
}