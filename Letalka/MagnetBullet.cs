using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Letalka
{
    class MagnetBullet : Bullet
    {
        float inactiveTime = 0.1f;
        float MagnetPower = 100f;
        public MagnetBullet(Vector2 position, float damage, float length, float width, Texture2D texture) : base(position, damage, length, width, texture)
        {
        }
        public override Bullet Clone()
        {
            return new MagnetBullet(position, damage, length, width, texture);
        }
        public override void Update(GameTime gameTime)
        {
            Vector2 a = World.getInstance().ClosestSolidObject(this);
            //DebugString.toPrint += "\n" + a;
            a /= a.LengthSquared();
            a *= MagnetPower;
            speed += a - speed/100;
            base.Update(gameTime);
        }
    }
}
