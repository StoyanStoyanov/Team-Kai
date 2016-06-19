namespace KaiFighterGame.Utilities
{ 
    using System.Collections.Generic;
    using Interfaces;

    public abstract class GameObject : IRenderable, ICollidable, IProducable<GameObject>
    {
        public const string CollisionGroupString = "GameObject";

        protected Position position;
        protected ObjectType objectType;
        protected string resources;
        protected string size; // Might be redundant, alter as needed
        protected string image; // Might be redundant, alter as needed

        /// <summary>
        /// Creates a game object.
        /// </summary>
        /// <param name="position">The position of the object.</param>
        /// <param name="objectType">The type of the game object.</param>
        /// <param name="resources">The resources of the object.</param>
        /// <param name="size">The size of the object.</param>
        /// <param name="image">The image of the object.</param>
        protected GameObject(Position position, ObjectType objectType, string resources = null, string size = null, string image = null)
        {
            this.position = position;
            this.objectType = objectType;
            this.resources = resources;
            this.size = size;
            this.image = image;
            this.IsDestroyed = false;
        }

        /// <summary>
        /// Gets the position of the object.
        /// </summary>
        public Position Position
        {
            protected set
            {
                this.position = new Position(value.X, value.Y);
            }

            get
            {
                return new Position(this.position.X, this.position.Y);
            }
        }

        /// <summary>
        /// Returns if the object is in state destroyed or not.
        /// </summary>
        public bool IsDestroyed { get; protected set; }

        /// <summary>
        /// Updates the state of the object.
        /// </summary>
        public abstract void Update();

        public virtual Position GetObjectPosition()
        {
            return this.position;
        }

        public virtual ObjectType GetObjectType()
        {
            return this.objectType;
        }

        public virtual string GetObjectResources()
        {
            return this.resources;
        }

        public virtual string GetObjectSize()
        {
            return this.size;
        }

        public virtual string GetObjectImage()
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