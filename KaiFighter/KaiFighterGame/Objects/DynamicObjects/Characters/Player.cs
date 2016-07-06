namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Projectiles;
    using Utilities;
    using System.Diagnostics;

    public class Player : Shooter
    {
        private const string CollisionGroupString = "Player";

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public Player(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float speed, int damage, int health, int cooldown) : 
            base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, speed, damage, health, cooldown)
        {
        }

        public override void Update(GameTime gameTime)
        {
            // Handles the users inputw
            this.HandleInput(Keyboard.GetState());       

            // update the dynamic object
            base.Update(gameTime);
        }

        public override void RespondToCollision(GameObject gameObject)
        {

            if (gameObject.ObjType == ObjectType.Wall)
            {

            this.PositionX = this.PreviousPositionX;
            this.PositionY = this.PreviousPositionY;
           
            }

            else if (gameObject.GetCollisionGroupString() == "Bullet")
            {
                this.Health -= (gameObject as Bullet).Damage;
            }
            else if (gameObject.GetCollisionGroupString() == "Archer" || 
                        gameObject.GetCollisionGroupString() == "Creep" || 
                        gameObject.GetCollisionGroupString() == "Wizard")
            {
                this.Health -= (gameObject as Character).Damage;
                this.PositionX = this.PreviousPositionX;
                this.PositionY = this.PreviousPositionY;
                }
                else if (gameObject.GetCollisionGroupString() == "BonusHealth")
                {
                    Random rnd = new Random();
                    this.Health += rnd.Next(-5, 10);
                }
                else if (gameObject.GetCollisionGroupString() == "Door")
                {
                //
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
    }
}