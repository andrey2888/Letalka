using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Letalka
{
    class Menu
    {
        Texture2D newGame, exit;
        KeyboardState currentKeyboardState;
        uint menuItem = 0;

        public void LoadContent(ContentManager content)
        {
            newGame = content.Load<Texture2D>("space/newgame");
            exit = content.Load<Texture2D>("space/exit");
        }
        public void Update(GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.W)  || currentKeyboardState.IsKeyDown(Keys.Up))
            {
                menuItem = 0;
            }
            if (currentKeyboardState.IsKeyDown(Keys.S) || currentKeyboardState.IsKeyDown(Keys.Down))
            {
                menuItem = 1;
            }
        }
        public void Draw(SpriteBatch batch)
        {
            float realw = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            float realh = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            float rw = realw / (float)newGame.Width;
            float rh = realh / (float)newGame.Height;
            switch (menuItem) {
                case 0:
                    batch.Draw(newGame, (rw > rh) ? Vector2.Zero : new Vector2((realw - (float)newGame.Width * rh) / 2, 0), null, 
                        Color.White, 0.0f, Vector2.Zero, (rw > rh) ? rw : rh, SpriteEffects.None, 1.0f);
                    break;
                case 1:
                    batch.Draw(exit, (rw > rh) ? Vector2.Zero : new Vector2((realw - (float)newGame.Width * rh) / 2, 0), null, 
                        Color.White, 0.0f, Vector2.Zero, (rw > rh) ? rw : rh, SpriteEffects.None, 1.0f);
                    break;
            }
        }
    }
}
