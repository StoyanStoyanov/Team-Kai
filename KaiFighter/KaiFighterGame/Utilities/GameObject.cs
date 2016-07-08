namespace KaiFighterGame.Utilities
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class ICOllidable : IRenderable, ICollidable, IProducable<ICOllidable>
    {
        private const string CollisionGroupString = "GameObject";

        private Vector2 position;
        private ObjectType objectType;
        private Texture2D image;
        private string imageFile;
        private Color? objectColor;
        private float objectScale;
        private float objectRotation;
        private float objectLayerDepth;

        /// <summary>
        /// Creates a game object.
        /// </summary>
        /// <param name="position">The position of the object.</param>
        /// <param name="objectType">The type of the game object.</param>
        /// <param name="resources">The resources of the object.</param>
        /// <param name="size">The size of the object.</param>
        /// <param name="image">The image of the object.</param>
        protected ICOllidable(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth)
        {
            this.ObjectColor = objColor;
            this.PositionX = position.X;
            this.PositionY = position.Y;

            this.objectType = objectType;
            this.imageFile = imageLocation;
            this.objectScale = scale;
            this.objectRotation = rotation;
            this.objectLayerDepth = layerDepth;
        }

        public ObjectType ObjType
        {
            get
            {
                return this.objectType;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)(this.PositionX - this.Width / 2 * this.objectScale),
                    (int)(this.PositionY - this.Height / 2 * this.objectScale), 
                    (int)(this.Width * this.objectScale - 10),
                    (int)(this.Height * this.objectScale - 10));
            }
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

        /// <summary>
        /// Gets the width of the object.
        /// </summary>
        public int Width
        {
            get
            {
                return this.image.Width;
            }
        }

        /// <summary>
        /// Gets the height of the object.
        /// </summary>
        public int Height
        {
            get
            {
                return this.image.Height;
            }
        }

        public Color? ObjectColor
        {
            get
            {
                return this.objectColor;
            }

            set
            {
                if (value == null)
                {
                    this.objectColor = Color.White;
                }
                else
                {
                    this.objectColor = value;
                }
            }
        }

        /// <summary>
        /// Initializes the object
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Updates the state of the object on the screen
        /// </summary>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Draws the object.
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            var origin = new Vector2(this.Width / 2f, this.Height / 2f);
            var rotation = this.objectRotation * (float)Math.PI / 180;
            spriteBatch.Draw(this.image, this.position, null, null, origin, rotation, new Vector2(this.objectScale, this.objectScale), this.ObjectColor, SpriteEffects.None, this.objectLayerDepth);
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


        public virtual IEnumerable<ICOllidable> ProduceObjects()
        {
            return new List<ICOllidable>();
        }

        public virtual void RespondToCollision(ICollidable gameObject)
        {
            // Descendants will override and implement this method.
        }
    }
}