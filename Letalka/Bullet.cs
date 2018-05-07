using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Letalka
{
    class Bullet:WorldObject
    {
        Texture2D texture;
        public Bullet(Vector2 position, float length, float width, Texture2D texture):base(position,length,width)
        {
            this.texture = texture;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 ratio = new Vector2(length / texture.Width, width / texture.Height);
            spriteBatch.Draw(texture, position, null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), ratio, SpriteEffects.None, 0.0f);
        }
    }
}
