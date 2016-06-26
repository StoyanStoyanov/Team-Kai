using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using KaiFighterGame.Utilities;
using Microsoft.Xna.Framework;

namespace KaiFighterGame.Objects.StaticObjects
{
    public class Obstacle : StaticObject
    {
        public Obstacle(Vector2 position, ObjectType objectType, string[] resources = null)
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
