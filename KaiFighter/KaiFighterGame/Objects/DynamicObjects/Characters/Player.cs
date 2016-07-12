namespace KaiFighterGame.Objects.DynamicObjects.Characters
{
    using System;
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using Projectiles;
    using Utilities;
    using Interfaces;
    using Exceptions;
    using Scenes;

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
            try
            {
                // Handles the users inputw
                this.HandleInput(Keyboard.GetState());
            }
            catch (BadInputException exc)
            {
                exc.ActivateError();
            }

            // update the dynamic object
            base.Update(gameTime);

            if (this.Health <= 0)
            {
                this.SaveToScoreBoard();

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
                && ((Bullet)gameObject).FriendlyFire == false)
            {
                this.Health -= ((Bullet)gameObject).Damage;
            }
            else if (gameObject.ObjType == ObjectType.Archer
                  || gameObject.ObjType == ObjectType.Creep
                  || gameObject.ObjType == ObjectType.Wizard)
            {
                this.Health -= ((Character)gameObject).Damage / 10;
                this.PositionX = this.PreviousPositionX;
                this.PositionY = this.PreviousPositionY;
            }
            else if (gameObject.ObjType == ObjectType.Bonus)
            {
                Random rnd = new Random();
                this.Health += rnd.Next(1, 30);
                this.Damage += rnd.Next(1, 20);
                this.Score += rnd.Next(1, 20);
            }
        }

        protected override void DeathActions()
        {
            SceneManager.LoadScene(new DeathScene());
        }

        private void HandleInput(KeyboardState keyState)
        {
            this.previousKeyboardState = this.currentKeyboardState;
            this.currentKeyboardState = Keyboard.GetState();

            Keys[] currentPressedKeys = this.currentKeyboardState.GetPressedKeys();

            if ((Array.IndexOf(currentPressedKeys, Keys.W) > -1 &&
                Array.IndexOf(currentPressedKeys, Keys.A) > -1 &&
                Array.IndexOf(currentPressedKeys, Keys.S) > -1 &&
                Array.IndexOf(currentPressedKeys, Keys.D) > -1) ||
                (Array.IndexOf(currentPressedKeys, Keys.Up) > -1 &&
                Array.IndexOf(currentPressedKeys, Keys.Down) > -1 &&
                Array.IndexOf(currentPressedKeys, Keys.Left) > -1 &&
                Array.IndexOf(currentPressedKeys, Keys.Right) > -1))
            {
                throw new BadInputException();
            }

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
        }

        private void SaveToScoreBoard()
        {
            bool isBigger = false;
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

                if (fileScore < this.Score)
                {
                    isBigger = true;
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
                writer.WriteLine(++deathsCount);

                if (isBigger == true)
                {
                    writer.WriteLine(this.Score);
                }
                else
                {
                    writer.WriteLine(fileScore);
                }

                writer.WriteLine(killsCount);
                writer.Close();
            }
        }
    }
}