namespace KaiFighterGame
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class EntryPoint
    {
        private static KaiFighterGame game = new KaiFighterGame();

        public static KaiFighterGame TheGame
        {
            get
            {
                return game;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            using (game)
            {
                game.Run();
            }   
        }
    }
}
