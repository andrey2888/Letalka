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
        public Texture2D bulletTexture;
        public GunType(float coolDown, float damage, float bulletSpeed, Texture2D bulletTexture)
        {
            this.coolDown = coolDown;
            this.damage = damage;
            this.bulletSpeed = bulletSpeed;
            this.bulletTexture = bulletTexture;
        }
        //bullet - prototipe?
        //кстати ИИ - стратегия наверн
    }
}
