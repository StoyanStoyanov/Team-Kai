namespace KaiFighterGame.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Utilities;

    public class Player : DynamicObject
    {
        private Vector2 playerPos;
        private ObjectType characterType;
        private Texture2D playerImage;
        private float playerSpeed;
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public Player(Vector2 position, ObjectType objectType, float speed, string[] resources = null) : base(position, objectType, speed, resources)
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
    }
}
