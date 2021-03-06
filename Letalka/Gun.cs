﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Letalka
{
    class Gun
    {
        private Random rand = new Random();
        float lastShot = 0;
        Vector2 position;
        GunType type;
        WorldObject parent;

        public Gun(Vector2 position, GunType type, WorldObject parent)
        {
            this.position = position;
            this.type = type;
            this.parent = parent;
        }

        public void Update(GameTime gameTime)
        {
            lastShot -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (lastShot < 0) lastShot = 0;
        }
        public void Fire()
        {
            if (lastShot < 0.0001)
            {
                lastShot = type.coolDown;
                Vector2 direction = new Vector2((float)Math.Cos(parent.angle),(float)Math.Sin(parent.angle));
                //Bullet bullet = new Bullet(parent.position + Vector2Extension.Rotate(position,parent.angle), 10, 5, type);
                Bullet bullet = type.bulletPrototype.Clone();
                bullet.position = parent.position + Vector2Extension.Rotate(position, parent.angle);
                bullet.angle = parent.angle;
                bullet.speed = new Vector2((float)Math.Cos(parent.angle + (float)rand.NextDouble() * type.accuracy - type.accuracy/2)*type.bulletSpeed,(float)Math.Sin(parent.angle)*type.bulletSpeed) + parent.speed;                
                World.getInstance().AddObject(bullet);
            }
        }
    }
}   