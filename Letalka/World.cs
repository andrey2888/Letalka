using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Letalka
{
    class World
    {

        public float Height;
        public float Width;

        static World instance = null;
        private World(){
            objects = new List<WorldObject>();
        }
        public static World getInstance() {
            if(instance == null) instance = new World();
            return instance;
        }
        public List<WorldObject> objects;
        public void Update(GameTime gameTime)
        {
            foreach (WorldObject wo in objects) {
                wo.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (WorldObject wo in objects)
            {
                 wo.Draw(spriteBatch);
            }
        }
    }
}
