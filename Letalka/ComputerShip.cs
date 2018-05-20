using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Letalka
{
    class ComputerShip:Player
    {
        KeyboardState currentKeyboardState;
        public Spaceship spaceship;
        private World world;
        public ComputerShip(Spaceship spaceship)
        {
            this.world = World.getInstance();
            this.spaceship = spaceship;
        }

        public void Update(GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();

            //Стратегия?
            //Vector2 direction = -spaceship.position + world.playerShip.position;
            Vector2 direction = world.ShortestPath(spaceship.position,world.playerShip.position);

            float angle = AngleFunc.Diff(direction.angle(),spaceship.angle);
            if (angle - spaceship.angularSpeed * 20 > 0) spaceship.TurnLeft();
            else spaceship.TurnRight();

            bool slowDown = spaceship.speed.Length() > 10;
            float sp = spaceship.speed.angle();

            bool facedForward = Math.Abs(AngleFunc.Diff(spaceship.speed.angle(), spaceship.angle)) < (float)Math.PI/2;
            bool facedRight   = Math.Abs(AngleFunc.Diff(spaceship.speed.angle(), spaceship.angle + (float)Math.PI/2)) < (float)Math.PI/2;
            /*
            DebugString.toPrint += "\n" + AngleFunc.Diff(spaceship.speed.angle(), spaceship.angle).ToString();
            DebugString.toPrint += "\n" + spaceship.speed.Length().ToString();
            DebugString.toPrint += "\n" + turning_right;*/
            
            if (slowDown)
            {
                if (facedForward) spaceship.GoBack();
                else spaceship.GoForward();
                if (facedRight) spaceship.GoLeft();
                else spaceship.GoRight();
            }
            else
            {
                spaceship.GoForward();
            }
            if (Math.Abs(angle) < 0.15f) spaceship.Fire();
            

        }
    }
}


