using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Letalka
{
    class PlayerShip:Player
    {

        public Spaceship spaceship;
        KeyboardState currentKeyboardState;
        public PlayerShip(Spaceship spaceship)
        {
            this.spaceship = spaceship;
        }
        public void Update(GameTime gameTime) {
            currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.W) || currentKeyboardState.IsKeyDown(Keys.Up))
            {
                spaceship.GoForward();
            }
            if (currentKeyboardState.IsKeyDown(Keys.S) || currentKeyboardState.IsKeyDown(Keys.Down))
            {
                spaceship.GoBack();
            }
            if (currentKeyboardState.IsKeyDown(Keys.A) || currentKeyboardState.IsKeyDown(Keys.Left))
            {
                spaceship.GoLeft();
            }
            if (currentKeyboardState.IsKeyDown(Keys.D) || currentKeyboardState.IsKeyDown(Keys.Right))
            {
                spaceship.GoRight();
            }
            if (currentKeyboardState.IsKeyDown(Keys.E))
            {
                spaceship.TurnRight();
            }
            if (currentKeyboardState.IsKeyDown(Keys.Q))
            {
                spaceship.TurnLeft();
            }
            if (currentKeyboardState.IsKeyDown(Keys.Space))
            {
                spaceship.Fire();
            }
            DebugString.toPrint = spaceship.HP + "   " + spaceship.AP;
            //spaceship.Update(gameTime);
        }
        
    }

}
