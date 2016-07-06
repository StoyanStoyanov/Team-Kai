namespace KaiFighterGame.UI
{
    using System;
    using Microsoft.Xna.Framework;
    using Utilities;
    using Microsoft.Xna.Framework.Graphics;
    using Global_Constants;
    using Microsoft.Xna.Framework.Input;

    public class Button : GameObject
    {
        private const int NUMBER_OF_BUTTONS = 3;
        private const int EASY_BUTTON_INDEX = 0;
        private const int MEDIUM_BUTTON_INDEX = 1;
        private const int HARD_BUTTON_INDEX = 2;
        private const int BUTTON_HEIGHT = 40;
        private const int BUTTON_WIDTH = 88;

        private Color[] buttonColor = new Color[NUMBER_OF_BUTTONS];
        private Rectangle[] buttonRectangle = new Rectangle[NUMBER_OF_BUTTONS];
        private UiButtonState[] buttonState = new UiButtonState[NUMBER_OF_BUTTONS];
        private Texture2D[] buttonTexture = new Texture2D[NUMBER_OF_BUTTONS];
        private double[] buttonTimer = new double[NUMBER_OF_BUTTONS];
        // mouse pressed and mouse just pressed
        private bool mpressed, prevMpressed = false;
        // mouse location in window
        private int mx, my;
        private double frameTime;

        public Button(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth) : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth)
        {
        }

        public override void LoadContent(Game theGame)
        {
            buttonTexture[EASY_BUTTON_INDEX] =
                theGame.Content.Load<Texture2D>(@"UI/button");
            buttonTexture[MEDIUM_BUTTON_INDEX] =
                theGame.Content.Load<Texture2D>(@"UI/button");
            buttonTexture[HARD_BUTTON_INDEX] =
                theGame.Content.Load<Texture2D>(@"UI/button");
        }

        public override void Initialize()
        {
            // starting x and y locations to stack buttons 
            // vertically in the middle of the screen
            int x = GameResolution.DefaultWidth / 2 - BUTTON_WIDTH / 2;
            int y = GameResolution.DefaultHeight / 2 -
                NUMBER_OF_BUTTONS / 2 * BUTTON_HEIGHT -
                (NUMBER_OF_BUTTONS % 2) * BUTTON_HEIGHT / 2;

            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {
                buttonState[i] = UiButtonState.UP;
                buttonColor[i] = Color.White;
                buttonTimer[i] = 0.0;
                buttonRectangle[i] = new Rectangle(x, y, BUTTON_WIDTH, BUTTON_HEIGHT);
                y += BUTTON_HEIGHT;
            }

            // IsMouseVisible = true;
        }

        public override void Update(GameTime gameTime)
        {
            // get elapsed frame time in seconds
            frameTime = gameTime.ElapsedGameTime.Milliseconds / 1000.0;

            // update mouse variables
            MouseState mouse_state = Mouse.GetState();
            mx = mouse_state.X;
            my = mouse_state.Y;
            prevMpressed = mpressed;
            mpressed = mouse_state.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;

            update_buttons();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {
                spriteBatch.Draw(buttonTexture[i], buttonRectangle[i], buttonColor[i]);
            }
               

        }

        // wrapper for hit_image_alpha taking Rectangle and Texture
        private bool hit_image_alpha(Rectangle rect, Texture2D tex, int x, int y)
        {
            return hit_image_alpha(0, 0, tex, tex.Width * (x - rect.X) /
                rect.Width, tex.Height * (y - rect.Y) / rect.Height);
        }

        // wraps hit_image then determines if hit a transparent part of image 
        private bool hit_image_alpha(float tx, float ty, Texture2D tex, int x, int y)
        {
            if (hit_image(tx, ty, tex, x, y))
            {
                uint[] data = new uint[tex.Width * tex.Height];
                tex.GetData<uint>(data);
                if ((x - (int)tx) + (y - (int)ty) *
                    tex.Width < tex.Width * tex.Height)
                {
                    return ((data[
                        (x - (int)tx) + (y - (int)ty) * tex.Width
                        ] &
                                0xFF000000) >> 24) > 20;
                }
            }
            return false;
        }


       //  determine if x,y is within rectangle formed by texture located at tx,ty
        private bool hit_image(float tx, float ty, Texture2D tex, int x, int y)
        {
            return (x >= tx &&
                x <= tx + tex.Width &&
                y >= ty &&
                y <= ty + tex.Height);
        }

        // determine state and color of button
        private void update_buttons()
        {
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {

                if (hit_image_alpha(
                    buttonRectangle[i], buttonTexture[i], mx, my))
                {
                    buttonTimer[i] = 0.0;
                    if (mpressed)
                    {
                        // mouse is currently down
                        buttonState[i] = UiButtonState.DOWN;
                        buttonColor[i] = Color.Blue;
                    }
                    else if (!mpressed && prevMpressed)
                    {
                        // mouse was just released
                        if (buttonState[i] == UiButtonState.DOWN)
                        {
                            //S button i was just down
                            buttonState[i] = UiButtonState.JUST_RELEASED;
                        }
                    }
                    else
                    {
                        buttonState[i] = UiButtonState.HOVER;
                        buttonColor[i] = Color.LightBlue;
                    }
                }
                else
                {
                    buttonState[i] = UiButtonState.UP;
                    if (buttonTimer[i] > 0)
                    {
                        buttonTimer[i] = buttonTimer[i] - frameTime;
                    }
                    else
                    {
                        buttonColor[i] = Color.White;
                    }
                }

                if (buttonState[i] == UiButtonState.JUST_RELEASED)
                {
                    take_action_on_button(i);
                }
            }
        }

        // Logic for each button click goes here
        private void take_action_on_button(int i)
        {
            // take action corresponding to which button was clicked
            switch (i)
            {
                case EASY_BUTTON_INDEX:
                    break;
                case MEDIUM_BUTTON_INDEX:
                    break;
                case HARD_BUTTON_INDEX:
                    break;
                default:
                    break;
            }
        }
    }
}