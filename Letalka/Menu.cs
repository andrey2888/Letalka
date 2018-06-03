using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Letalka
{
    class Menu : IGameState
    {
        Texture2D newGame, exit;
        KeyboardState currentKeyboardState;
        uint menuItem = 0;

        public void LoadContent(GameContext context)
        {
            newGame = context.Content.Load<Texture2D>("space/newgame");
            exit = context.Content.Load<Texture2D>("space/exit");
        }

        public void Update(GameContext context, GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.W) || currentKeyboardState.IsKeyDown(Keys.Up))
            {
                menuItem = 0;
            }
            if (currentKeyboardState.IsKeyDown(Keys.S) || currentKeyboardState.IsKeyDown(Keys.Down))
            {
                menuItem = 1;
            }
            if (menuItem == 1 && currentKeyboardState.IsKeyDown(Keys.Enter))
            {
                context.Exit();
            }
            if (menuItem == 0 && currentKeyboardState.IsKeyDown(Keys.Enter))
            {
                context.State = StateFactory.GetState(typeof(Game1));
            }
        }

        public void Draw(GameContext context, GameTime gameTime)
        {
            float realw = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            float realh = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            float rw = realw / (float)newGame.Width;
            float rh = realh / (float)newGame.Height;
            switch (menuItem)
            {
                case 0:
                    context.SpriteBatch.Draw(newGame, (rw > rh) ? Vector2.Zero : new Vector2((realw - (float)newGame.Width * rh) / 2, 0), null,
                        Color.White, 0.0f, Vector2.Zero, (rw > rh) ? rw : rh, SpriteEffects.None, 1.0f);
                    break;
                case 1:
                    context.SpriteBatch.Draw(exit, (rw > rh) ? Vector2.Zero : new Vector2((realw - (float)newGame.Width * rh) / 2, 0), null,
                        Color.White, 0.0f, Vector2.Zero, (rw > rh) ? rw : rh, SpriteEffects.None, 1.0f);
                    break;
            }

        }

        public void Initialize(GameContext context)
        {
            
        }

        public void UnloadContent(GameContext context)
        {

        }
    }
}
