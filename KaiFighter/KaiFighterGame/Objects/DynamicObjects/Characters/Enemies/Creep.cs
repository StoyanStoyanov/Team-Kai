namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities;

    public class Creep : Character
    {
        private const string CollisionGroupString = "Creep";

        public Creep(Vector2 position, string imageLocation, ObjectType objectType, Color? objColor, float scale, float rotation, float layerDepth, float movementSpeed, double damage, double health)
            : base(position, imageLocation, objectType, objColor, scale, rotation, layerDepth, movementSpeed, damage, health)
        {
            
        }

       /*public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
        
        public override void LoadContent(Game theGame)
        {
            throw new NotImplementedException();
        }*/

      
        public override void Update(GameTime gameTime)
        {
            ////move
            
            //we can change this to only one direction 
            /*Vector2 test = new Vector2(150, 150);
            this.MoveTowards(test);*/

            Random rnd = new Random();
            int move = rnd.Next(1, 4);
            switch (move)
            {
                case 1: this.MoveUp(); break;
                case 2: this.MoveDown(); break;
                case 3: this.MoveLeft(); break;
                case 4: this.MoveRight(); break;

            }

            // update the dynamic object
            base.Update(gameTime);

            if (this.Health <= 0)
            {
                SceneManager.DestroyObject(this);
            }
        }


        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}