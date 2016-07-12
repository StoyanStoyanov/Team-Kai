namespace KaiFighterGame.Utilities
{
    using Interfaces;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Defines a dynamic object in the game. All moving objects should inherit the DynamicObject class.
    /// </summary>
    public abstract class DynamicObject : GameObject, IMovable
    {
        private Vector2 objDirection;
        private float objSpeed;
        private bool movingTowards;
        private bool movingWithoutStop;
        private Vector2 destination;
        private Vector2 start;
        private Vector2 previousPosition;
        private float distance;

        public DynamicObject(Vector2 position, string imageLocation, ObjectType objectType, Color objColor, float scale, float rotation, float layerDepth, float movementSpeed) 
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth)
        {
            this.objSpeed = movementSpeed;
            this.objDirection = new Vector2(1, 1);
            this.movingTowards = false;
            this.movingWithoutStop = false;
        }

        public float PreviousPositionX
        {
            get
            {
                return this.previousPosition.X;
            }
        }

        public float PreviousPositionY
        {
            get
            {
                return this.previousPosition.Y;
            }
        }

        public void MoveUp()
        {
            this.objDirection.Y = -1;
        }

        public void MoveDown()
        {
            this.objDirection.Y = 1;
        }

        public void MoveLeft()
        {
            this.objDirection.X = -1;
        }

        public void MoveRight()
        {
            this.objDirection.X = 1;
        }

        public void MoveTowards(Vector2 dest)
        {
            this.movingTowards = true;
            this.destination = dest;
            this.start = new Vector2(this.PositionX, this.PositionY);
            this.distance = Vector2.Distance(this.start, this.destination);
        }

        public void MoveWithoutStop(Vector2 direction)
        {
            this.movingWithoutStop = true;
            this.objDirection = direction;
        }

        public override void Update(GameTime gameTime)
        {
            this.previousPosition.X = this.PositionX;
            this.previousPosition.Y = this.PositionY;

            if (this.objDirection.Y == -1)
            {
                this.PositionY -= this.objSpeed;
            }

            if (this.objDirection.Y == 1)
            {
                this.PositionY += this.objSpeed;
            }

            if (this.objDirection.X == -1)
            {
                this.PositionX -= this.objSpeed;
            }

            if (this.objDirection.X == 1)
            {
                this.PositionX += this.objSpeed;
            }

            // start moving towars destination
            if (this.movingTowards == true)
            {
                Vector2 difference = this.destination - new Vector2(this.PositionX, this.PositionY);
                difference.Normalize();

                this.PositionX += difference.X * this.objSpeed;
                this.PositionY += difference.Y * this.objSpeed;

                if (Vector2.Distance(this.start, new Vector2(this.PositionX, this.PositionY)) >= this.distance)
                {
                    this.movingTowards = false;
                }
            }

            // start moving without stop (suitable for bullets)
            if (this.movingWithoutStop == true)
            {
                this.PositionY += this.objSpeed * this.objDirection.Y;
                this.PositionX += this.objSpeed * this.objDirection.X;
            }

            this.objDirection.Normalize();
        }
    }
}