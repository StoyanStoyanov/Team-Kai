namespace KaiFighterGame.Interfaces
{
    using System;

    public interface IUserInterface
    {
        /// <summary>
        /// Handles the left movement requests.
        /// </summary>
        event EventHandler OnLeftRequest;

        /// <summary>
        /// Handles the right movement requests.
        /// </summary>
        event EventHandler OnRightRequest;

        /// <summary>
        /// Handles the up movement requests.
        /// </summary>
        event EventHandler OnUpRequest;

        /// <summary>
        /// Handles the down movement requests.
        /// </summary>
        event EventHandler OnDownRequest;

        /// <summary>
        /// Handles the action/fire requests.
        /// </summary>
        event EventHandler OnActionRequest;

        /// <summary>
        /// Processes the user input.
        /// </summary>
        void ProcessInput();
    }
}