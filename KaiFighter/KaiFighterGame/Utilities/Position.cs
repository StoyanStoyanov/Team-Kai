namespace KaiFighterGame.Utilities
{
    /// <summary>
    /// The position of every object in the game.
    /// </summary>
    public class Position
    {
        public Position(int x, int y) 
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Determines if two Positions are equal.
        /// </summary>
        public override bool Equals(object obj)
        {
            Position objPosition = obj as Position;
            if (objPosition == null)
            {
                return false;
            }

            // Positions are equal if both their coordinates are equal.
            return this.X == objPosition.X && this.Y == objPosition.Y;
        }

        /// <summary>
        /// Gets the hash code of the Position.
        /// It concatenates the first 16 bits of the X coordinate
        /// with the first 16 bits of the Y coordinate.
        /// </summary>
        /// <returns>The calculated hash code.</returns>
        public override int GetHashCode()
        {
            return (this.X.GetHashCode() << 16) | (this.Y.GetHashCode() & 0xffff);
        }
    }
}