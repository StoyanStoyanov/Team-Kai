namespace KaiFighterGame
{
    using System;

    /// <summary>
    /// The main class.
    /// </summary>
    public static class EntryPoint
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            using (var game = new KaiFighterGame())
            {
                game.Run();
            }   
        }
    }
}
