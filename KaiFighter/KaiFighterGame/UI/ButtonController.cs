namespace KaiFighterGame.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

    public abstract class ButtonController
    {
        private List<Button> buttons;
        private Button currentSelectedButton;
        private bool disabledButtons;
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public ButtonController()
        {
            this.buttons = new List<Button>();
            this.disabledButtons = false;
        }

        protected List<Button> Buttons
        {
            get
            {
                return this.buttons;
            }

            private set
            {
                this.buttons = value;
            }
        }

        protected Button CurrentSelectedButton
        {
            get
            {
                return this.currentSelectedButton;
            }

            set
            {
                this.currentSelectedButton = value;
            }
        }

        public virtual void Update(GameTime gametime)
        {
            if (this.disabledButtons == false)
            {
                this.previousKeyboardState = this.currentKeyboardState;
                this.currentKeyboardState = Keyboard.GetState();
                int currentSelectedButtonIndex = this.Buttons.IndexOf(this.CurrentSelectedButton);

                this.CurrentSelectedButton.SelectButton();

                if (this.currentKeyboardState.IsKeyDown(Keys.Up) && this.previousKeyboardState.IsKeyUp(Keys.Up))
                {
                    this.CurrentSelectedButton.DeselectButton();

                    if (currentSelectedButtonIndex == 0)
                    {
                        this.CurrentSelectedButton = this.Buttons[this.Buttons.Count - 1];
                    }
                    else
                    {
                        this.CurrentSelectedButton = this.Buttons[currentSelectedButtonIndex - 1];
                    }
                }
                else if (this.currentKeyboardState.IsKeyDown(Keys.Down) && this.previousKeyboardState.IsKeyUp(Keys.Down))
                {
                    this.CurrentSelectedButton.DeselectButton();

                    if (currentSelectedButtonIndex == this.Buttons.Count - 1)
                    {
                        this.currentSelectedButton = this.Buttons[0];
                    }
                    else
                    {
                        this.CurrentSelectedButton = this.Buttons[currentSelectedButtonIndex + 1];
                    }
                }
                else if (this.currentKeyboardState.IsKeyUp(Keys.Enter) && this.previousKeyboardState.IsKeyDown(Keys.Enter))
                {
                    this.disabledButtons = true;
                    this.CurrentSelectedButton.PressButton();
                }
            }
        }
    }
}