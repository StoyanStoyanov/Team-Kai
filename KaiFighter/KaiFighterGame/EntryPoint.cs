namespace KaiFighterGame
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class EntryPoint
    {
        private static readonly KaiFighterGame Game = new KaiFighterGame();

        public static KaiFighterGame TheGame
        {
            get
            {
                return Game;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            using (Game)
            {
                Game.Run();
            }   
        }
    }
}
