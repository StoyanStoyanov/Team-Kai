namespace KaiFighterGame.Utilities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    // this makes the game work on all kings of screens
    public static class ScalingViewportAdapter
    {
        private static int virtualWidth;
        private static int virtualHeight;

        public static int VirtualWidth
        {
            get
            {
                return virtualWidth;
            }

            set
            {
                virtualWidth = value;
            }
        }
        
        public static int VirtualHeight
        {
            get
            {
                return virtualHeight;
            }

            set
            {
                virtualHeight = value;
            }
        }

        public static Matrix GetScaleMatrix(GraphicsDevice graphDevice)
        {
            var scaleX = (float)graphDevice.Viewport.Width / VirtualWidth;
            var scaleY = (float)graphDevice.Viewport.Height / VirtualHeight;
            return Matrix.CreateScale(scaleX, scaleY, 1.0f);
        }
    }
}
