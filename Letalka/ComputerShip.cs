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
        bool turning_right = true;
        public void Update(GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();

            //Стратегия?
            Vector2 direction = spaceship.position - world.playerShip.position;
            float angle = AngleFunc.Diff(direction.angle(),spaceship.angle);

            if (angle > 0.01) turning_right = true;
            else if (angle < 0.01) turning_right = false;

            if (turning_right)
            {
                float descr = spaceship.lth.turnSpeed * spaceship.lth.turnSpeed / 4 + 4 * spaceship.angularSpeed * angle;
                //DebugString.toPrint = descr.ToString();
                float time1 = (angle + (float)Math.Sqrt(descr)) / spaceship.lth.turnSpeed;
                float time2 = Math.Abs(angle) / spaceship.lth.turnSpeed;
                if (time1 < time2)
                    spaceship.TurnLeft();
                else spaceship.TurnRight();
            }
            else
            {
                float descr = spaceship.lth.turnSpeed * spaceship.lth.turnSpeed / 4 - 4 * spaceship.angularSpeed * angle;
                //DebugString.toPrint = descr.ToString();
                float time1 = (-angle + (float)Math.Sqrt(descr)) / spaceship.lth.turnSpeed;
                float time2 = Math.Abs(angle) / spaceship.lth.turnSpeed;
                if (time1 < time2)
                    spaceship.TurnRight();
                else spaceship.TurnLeft();
            }

            bool slowDown = spaceship.speed.Length() > 10;
            float sp = spaceship.speed.angle();

            bool facedForward = Math.Abs(AngleFunc.Diff(spaceship.speed.angle(), spaceship.angle)) < (float)Math.PI/2;
            bool facedRight   = Math.Abs(AngleFunc.Diff(spaceship.speed.angle(), spaceship.angle + (float)Math.PI)) < (float)Math.PI;
            /*DebugString.toPrint += "\n" + facedForward.ToString();
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
            if (Math.Abs(AngleFunc.Diff(angle, (float) Math.PI)) < 0.1) spaceship.Fire();
            //if ((spaceship.speed * Vector2.UnitX.Rotate(spaceship.angle)).Length() < 10f) spaceship.GoForward();
            //else spaceship.GoBack();

        }
    }
}


