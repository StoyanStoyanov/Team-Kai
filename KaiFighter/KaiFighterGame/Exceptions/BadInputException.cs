namespace KaiFighterGame.Exceptions
{
    using System;
    using System.Timers;
    using GlobalConstants;
    using Microsoft.Xna.Framework.Audio;
    using Utilities;

    public class BadInputException : ApplicationException
    {
        private SoundEffect effect;
        private Timer someTimer;

        public BadInputException()
        {
            this.effect = EntryPoint.TheGame.Content.Load<SoundEffect>(AudioAddresses.ErrorSound);

            this.someTimer = new Timer();
            this.someTimer.Interval = 3000;
            this.someTimer.Elapsed += new ElapsedEventHandler(DeActivateError);
        }

        public void ActivateError()
        {
            SceneManager.PauseScene();

            this.effect.Play();

            this.someTimer.Start();
        }

        private void DeActivateError(object source, ElapsedEventArgs e)
        {
            this.someTimer.Stop();

            this.someTimer.Elapsed -= new ElapsedEventHandler(DeActivateError);

            this.someTimer.Dispose();

            SceneManager.UnpauseScene();
        }
    }
}