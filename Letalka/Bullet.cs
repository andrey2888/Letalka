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
        float flightTime = 0;
        float invincibleTime = 0.08f;
        float lifeTime = 10;
        public Bullet(Vector2 position, float length, float width, Texture2D texture):base(position,length,width)
        {
            this.texture = texture;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 ratio = new Vector2(length / texture.Width, width / texture.Height);
            spriteBatch.Draw(texture, position, null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), ratio, SpriteEffects.None, 0.0f);
        }
        public override void Update(GameTime gameTime)
        {
            flightTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);

        }
        public override void onCollision(WorldObject other)
        {
            if (flightTime > invincibleTime)
            {
                deleteMe = true;
                other.getDamage(3.333f);
            }
        }
    }
}
