using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Letalka
{
    class PlayerShip
    {

        public Spaceship spaceship;
        KeyboardState currentKeyboardState;
        public PlayerShip(Spaceship spaceship)
        {
            this.spaceship = spaceship;
        }
        public void Update(GameTime gameTime) {
            currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.W))
            {
                spaceship.GoForward();
            }
            if (currentKeyboardState.IsKeyDown(Keys.S))
            {
                spaceship.GoBack();
            }
            if (currentKeyboardState.IsKeyDown(Keys.A))
            {
                spaceship.GoLeft();
            }
            if (currentKeyboardState.IsKeyDown(Keys.D))
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
            //spaceship.Update(gameTime);
        }
        
    }

}
