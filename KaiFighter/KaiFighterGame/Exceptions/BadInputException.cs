namespace KaiFighterGame.Exceptions
{
    using System;
    using System.Timers;
    using Microsoft.Xna.Framework.Audio;

    using GlobalConstants;
    using Utilities;

    /// <summary>
    /// The custom exception class in the game.
    /// </summary>
    public class BadInputException : ApplicationException
    {
        private SoundEffect effect;
        private Timer someTimer;

        public BadInputException()
        {
            this.effect = EntryPoint.TheGame.Content.Load<SoundEffect>(AudioAddresses.ErrorSound);

            this.someTimer = new Timer();
            this.someTimer.Interval = 3000;
            this.someTimer.Elapsed += new ElapsedEventHandler(this.DeActivateError);
        }

        /// <summary>
        /// Activates the error effect.
        /// </summary>
        public void ActivateError()
        {
            SceneManager.PauseScene();

            this.effect.Play();

            this.someTimer.Start();
        }

        /// <summary>
        /// Deactivates the error effect.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void DeActivateError(object source, ElapsedEventArgs e)
        {
            this.someTimer.Stop();

            this.someTimer.Elapsed -= new ElapsedEventHandler(this.DeActivateError);

            this.someTimer.Dispose();

            SceneManager.UnpauseScene();
        }
    }
}