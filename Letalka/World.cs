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
        //ToDo:Player list
        public float Height;
        public float Width;
        public List<WorldObject> objects;
        public List<Player> players;
        public Spaceship playerShip;


        static World instance = null;
        private World(){
            objects = new List<WorldObject>();
            players = new List<Player>();
        }
        public static World getInstance() {
            if(instance == null) instance = new World();
            return instance;
        }
        public void Update(GameTime gameTime)
        {
            foreach (Player p in players)
            {
                p.Update(gameTime);
            }
            foreach (WorldObject wo in objects) {
                wo.Update(gameTime);
            }
            calculateCollisions();
            cleanUp();

        }
        private void calculateCollisions() {
            //ToDo: better collision algorithm
            foreach (WorldObject wo1 in objects)
            {
                foreach (WorldObject wo2 in objects)
                {
                    if (wo1 != wo2 && (wo1.position - wo2.position).LengthSquared() < (wo1.dimentoins + wo2.dimentoins) )
                    {
                        wo1.onCollision(wo2);
                        wo2.onCollision(wo1);
                    }
                }
            }
        }
        private void cleanUp()
        {
            for(int i = 0; i < objects.Count; i++)
            {
                if (objects[i].deleteMe) objects.Remove(objects[i]);
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
