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

    class Creep: DynamicObject
    {
        public Creep(Vector2 position, ObjectType objectType, float movementSpeed, int power, string[] resources = null)
            : base(position, objectType, movementSpeed,power, resources)
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

        public override void RespondToCollision(GameObject gameObject)
        {
            if (gameObject.GetType )

        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
