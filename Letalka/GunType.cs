using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Letalka
{
    class GunType
    {
        public float coolDown;
        public float damage;
        public float bulletSpeed;
        public Bullet bulletPrototype;
        public float accuracy;
        //public Texture2D bulletTexture;
        public GunType(float coolDown, float damage, float bulletSpeed, Bullet bulletPrototype, float accuracy = 0)
        {
            this.coolDown = coolDown;
            this.damage = damage;
            this.bulletSpeed = bulletSpeed;
            this.bulletPrototype = bulletPrototype;
            this.accuracy = accuracy;
        }
        //bullet - prototipe?
        //кстати ИИ - стратегия наверн
    }
}
