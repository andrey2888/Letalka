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
        //public Texture2D bulletTexture;
        public GunType(float coolDown, float damage, float bulletSpeed, Bullet bulletPrototype)
        {
            this.coolDown = coolDown;
            this.damage = damage;
            this.bulletSpeed = bulletSpeed;
            this.bulletPrototype = bulletPrototype;
        }
        //bullet - prototipe?
        //кстати ИИ - стратегия наверн
    }
}
