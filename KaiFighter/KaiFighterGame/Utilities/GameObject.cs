namespace KaiFighterGame.Utilities
{
    using System.Collections.Generic;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class GameObject : IRenderable, ICollidable, IProducable<GameObject>
    {
        private const string CollisionGroupString = "GameObject";

        private Vector2 position;
        private ObjectType objectType;
        private Texture2D image;
        private string imageFile;

        /// <summary>
        /// Creates a game object.
        /// </summary>
        /// <param name="position">The position of the object.</param>
        /// <param name="objectType">The type of the game object.</param>
        /// <param name="resources">The resources of the object.</param>
        /// <param name="size">The size of the object.</param>
        /// <param name="image">The image of the object.</param>
        protected GameObject(Vector2 position, string imageLocation, ObjectType objectType)
        {
            this.PositionX = position.X;
            this.objectType = objectType;
            this.IsDestroyed = false;
            this.imageFile = imageLocation;
        }

        /// <summary>
        /// Gets and sets the X position of the object.
        /// </summary>
        public float PositionX
        {
            get
            {
                return this.position.X;
            }

            set
            {
                this.position.X = value;
            } 
        }

        /// <summary>
        /// Gets and sets the Y position of the object.
        /// </summary>
        public float PositionY
        {
            get
            {
                return this.position.Y;
            }

            set
            {
                this.position.Y = value;
            }
        }

        // Get the width of the object
        public int Width
        {
            get
            {
                return this.image.Width;
            }
        }

        // Get the height of the object
        public int Height
        {
            get
            {
                return this.image.Height;
            }
        }

        /// <summary>
        /// Returns if the object is in state destroyed or not.
        /// </summary>
        public bool IsDestroyed { get; protected set; }

        /// <summary>
        /// Updates the state of the object on the screen
        /// </summary>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Draws the object.
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, new Vector2(this.PositionX, this.PositionY), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Loads the content used by the object.
        /// </summary>
        public virtual void LoadContent(Game theGame)
        {
            this.image = theGame.Content.Load<Texture2D>(this.imageFile);
        }

        /// <summary>
        /// Disposes the content loaded by the object.
        /// </summary>
        public virtual void UnloadContent()
        {
            this.image.Dispose();
        }

        public virtual Vector2 GetObjectPosition()
        {
            return this.position;
        }

        public virtual ObjectType GetObjectType()
        {
            return this.objectType;
        }

        public virtual bool CanCollideWith(string otherCollisionGroupString)
        {
            return CollisionGroupString == otherCollisionGroupString;
        }

        public virtual string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }

        public virtual IEnumerable<GameObject> ProduceObjects()
        {
            return new List<GameObject>();
        }

        public virtual void RespondToCollision(GameObject gameObject)
        {
            // Descendants will override and implement this method.
        }
    }
}