﻿using System;
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
        protected Texture2D texture;
        float flightTime = 0;
        float invincibleTime = 0.05f;//calculate this
        float lifeTime = 10;
        protected float damage;
        public Bullet(Vector2 position, float damage, float length, float width, Texture2D texture, bool solid = false):base(position,length,width)
        {
            this.solid = solid;
            this.damage = damage;
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
            if (flightTime > lifeTime) deleteMe = true;
            base.Update(gameTime);

        }
        public override void onCollision(WorldObject other)
        {
            if (flightTime > invincibleTime)
            {
                deleteMe = true;
                other.getDamage(damage);
            }
        }
        public virtual Bullet Clone()
        {
            return new Bullet(position,damage,length,width,texture,solid);
        }
    }
}
