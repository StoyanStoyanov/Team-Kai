using KaiFighterGame.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace KaiFighterGame.Objects.StaticObjects
{
    public class Bonus : StaticObject
    {
        public Bonus(Vector2 position, ObjectType objectType, string[] resources = null) 
            : base(position, objectType, resources)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void LoadObject(Texture2D texture)
        {
            throw new NotImplementedException();
        }

     
        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
