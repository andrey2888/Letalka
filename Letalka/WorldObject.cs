using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Letalka
{
    class WorldObject
    {
        public WorldObject(Vector2 position, float length, float width)
        {
            this.position = position;
            this.speed = Vector2.Zero;
            this.angle = 0;
            this.angularSpeed = 0;
            this.length = length;
            this.width = width;
        }

        public Vector2 position; //private
        public Vector2 speed;
        public float length;
        public float width;
        public float angle;
        public float angularSpeed;
        //public double mass;
        public virtual void Update(GameTime gameTime)
        {
            
            position += speed;
            angle += angularSpeed;
            World world = World.getInstance();
            if (position.X >= world.Width)
            {
                position.X -= world.Width;
            }
            else if (position.X < 0)
            {
                position.X += world.Width;
            }else if (position.Y >= world.Height)
            {
                position.Y -= world.Height;
            }
            else if (position.Y < 0)
            {
                position.Y += world.Height;
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
        public void ApplyForce(Vector2 direction) {
            speed += direction;
        }
    }
}
