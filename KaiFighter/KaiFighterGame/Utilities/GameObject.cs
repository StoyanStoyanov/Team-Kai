namespace KaiFighterGame.Utilities
{
    using System.Collections.Generic;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class GameObject : IRenderable, ICollidable, IProducable<GameObject>
    {
        public const string CollisionGroupString = "GameObject";

        protected Vector2 position;
        protected ObjectType objectType;
        protected string[] resources; // this needs rethinking
        protected Texture2D image; // Later this will be an animation

        /// <summary>
        /// Creates a game object.
        /// </summary>
        /// <param name="position">The position of the object.</param>
        /// <param name="objectType">The type of the game object.</param>
        /// <param name="resources">The resources of the object.</param>
        /// <param name="size">The size of the object.</param>
        /// <param name="image">The image of the object.</param>
        protected GameObject(Vector2 position, ObjectType objectType, string[] resources = null)
        {
            this.Position = position;
            this.objectType = objectType;
            this.resources = resources;
            this.IsDestroyed = false;
        }

        /// <summary>
        /// Gets the position of the object.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return new Vector2(this.position.X, this.position.Y);
            }

            protected set
            {
                this.position = value;
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
        /// Initializes the object.
        /// </summary>
        public abstract void LoadObject(Texture2D texture); // could later add more things (sounds, etc.)

        /// <summary>
        /// Updates the state of the object.
        /// </summary>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Draws the object.
        /// </summary>
        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual Vector2 GetObjectPosition()
        {
            return this.position;
        }

        public virtual ObjectType GetObjectType()
        {
            return this.objectType;
        }

        public virtual string[] GetObjectResources()
        {
            return this.resources;
        }

        public virtual Texture2D GetObjectImage()
        {
            return this.image;
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

        public virtual void RespondToCollision(CollisionData collisionData)
        {
            // Descendants will override and implement this method.
        }
    }
}