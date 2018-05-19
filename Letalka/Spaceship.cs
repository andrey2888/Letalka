using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Letalka
{
    class Spaceship:WorldObject
    {
        public LTH lth;
        //public WorldObject body;
        public Texture2D texture; //Finga
        public float HP = 100;
        public float AP = 100;
        private List<Gun> Guns;
        
        public Spaceship(Texture2D texture, LTH lth, Vector2 position, float angle):base(position, lth.length, lth.width)
        {
            this.angle   = angle;
            this.texture = texture;
            this.lth     = lth;
            Guns = new List<Gun>();
        }
        public void AddGun(GunType type, Vector2 position) {
            Guns.Add(new Gun(position,type,this));
        }
        /*public void Initialize()
        {

        }*/
        
        //ToDo: make fps independent
        public void GoForward()
        {
            speed += new Vector2((float)Math.Cos(angle) * lth.forwardSpeed, (float)Math.Sin(angle) * lth.forwardSpeed);
        }
        public void GoBack(){
            speed -= new Vector2((float)Math.Cos(angle) * lth.backwardSpeed, (float)Math.Sin(angle) * lth.backwardSpeed);
        }
        public void GoLeft()
        {
            speed += new Vector2((float)Math.Cos(angle - Math.PI / 2) * lth.strafeSpeed, (float)Math.Sin(angle - Math.PI / 2) * lth.strafeSpeed);
        }
        public void GoRight()
        {
            speed += new Vector2((float)Math.Cos(angle + Math.PI / 2) * lth.strafeSpeed, (float)Math.Sin(angle + Math.PI / 2) * lth.strafeSpeed);
        }
        public void TurnLeft()
        {
            angularSpeed += lth.turnSpeed;

        }
        public void TurnRight()
        {
            angularSpeed -= lth.turnSpeed;
        }
        public void Fire()
        {
            foreach (Gun g in Guns)
            {
                g.Fire();
            }
        }
        public override void onCollision(WorldObject other)
        {
           
        }
        public override void getDamage(float damage)
        {
            if (damage < AP)
            {
                AP -= damage;
                damage = 0;
            }
            else
            {
                AP = 0;
                damage -= AP;
            }
            HP -= damage;
            if (HP < 0) deleteMe = true;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 ratio = new Vector2(length/texture.Width,width/texture.Height);
            World world = World.getInstance();

            spriteBatch.Draw(texture, position, null, Color.White, angle, new Vector2(texture.Width/2,texture.Height/2), ratio, SpriteEffects.None, 0.0f);
            //ToDo: ifs
            spriteBatch.Draw(texture, position + new Vector2(world.Width,0 ), null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), ratio, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(texture, position + new Vector2(0,world.Height), null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), ratio, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(texture, position - new Vector2(world.Width,0 ), null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), ratio, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(texture, position - new Vector2(0,world.Height), null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), ratio, SpriteEffects.None, 0.0f);
        }
        public override void Update(GameTime gameTime)
        {
            AP += 10 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (AP > 100) AP = 100;
            foreach (Gun g in Guns)
            {
                g.Update(gameTime);
            }
            base.Update(gameTime);
        }
    }

    
}
