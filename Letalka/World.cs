﻿using System;
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
        private List<WorldObject> objects;
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
        public void AddObject(WorldObject worldObject)
        {
            objects.Add(worldObject);
        }
        private void calculateCollisions() {
            //ToDo: better collision algorithm
            foreach (WorldObject wo1 in objects)
            {
                foreach (WorldObject wo2 in objects)
                {
                    if (wo1 != wo2 && (wo1.position - wo2.position).LengthSquared() < (wo1.dimentoins + wo2.dimentoins) )
                    {
                       if(wo2.solid) wo1.onCollision(wo2);
                       //if(wo1.solid) wo2.onCollision(wo1);
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
        public void DeleteAll()
        {
            objects.Clear();
             /*for(int i = 0; i < objects.Count; i++)
            {
                objects.Remove(objects[i]);
            }*/
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (WorldObject wo in objects)
            {
                 wo.Draw(spriteBatch);
            }
        }

        public Vector2 ShortestPath(Vector2 a, Vector2 b) {
            Vector2 ret = b - a;
            Vector2 b1 = b + new Vector2(Width, 0);
            if (b1.LengthSquared() < b.LengthSquared()) b = b1;
            b1 = b + new Vector2(Width, Height);
            if (b1.LengthSquared() < b.LengthSquared()) b = b1;
            b1 = b + new Vector2(0, Height);
            if (b1.LengthSquared() < b.LengthSquared()) b = b1;
            b1 = b + new Vector2(-Width, Height);
            if (b1.LengthSquared() < b.LengthSquared()) b = b1;
            b1 = b + new Vector2(-Width, 0);
            if (b1.LengthSquared() < b.LengthSquared()) b = b1;
            b1 = b + new Vector2(-Width, -Height);
            if (b1.LengthSquared() < b.LengthSquared()) b = b1;
            b1 = b + new Vector2(0, -Height);
            if (b1.LengthSquared() < b.LengthSquared()) b = b1;
            b1 = b + new Vector2(Width, -Height);
            if (b1.LengthSquared() < b.LengthSquared()) b = b1;

            return ret;
        }
        public Vector2 ClosestObject(WorldObject a)
        {
            Vector2 ret = new Vector2(Width,Height);
            foreach (WorldObject wo1 in objects)
            {
                if (a != wo1)
                {
                    Vector2 ret2 = ShortestPath(a.position, wo1.position);
                    if (ret.LengthSquared() > ret2.LengthSquared()) ret = ret2;
                }
            }
            return ret;
        }
        public Vector2 ClosestSolidObject(WorldObject a)
        {
            Vector2 ret = new Vector2(Width, Height);
            foreach (WorldObject wo1 in objects)
            {
                if (a != wo1 && wo1.solid)
                {
                    Vector2 ret2 = ShortestPath(a.position, wo1.position);
                    if (ret.LengthSquared() > ret2.LengthSquared()) ret = ret2;
                }
            }
            return ret;
        }
    }
}
