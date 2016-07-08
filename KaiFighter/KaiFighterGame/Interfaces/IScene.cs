namespace KaiFighterGame.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IScene
    {
        void Load();

        void Update(GameTime gameTime);
    }
}