namespace KaiFighterGame.Objects.DynamicObjects.Characters.Enemies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities;
    class Archer : DynamicObject
    {
        public Archer(Vector2 position, ObjectType objectType, float movementSpeed, string[] resources = null)
            : base(position, objectType, movementSpeed, resources)
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

        public override void RespondToCollision(GameObject gameObject)
        {

        }
    }
}
