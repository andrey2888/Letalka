using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Letalka
{
    public class DebugString : Observer
    {
        SpriteFont spriteFont;
        SpriteBatch batch;
        
        public DebugString(GameContext context)
        {
            spriteFont = context.Content.Load<SpriteFont>("Font");
            batch = context.SpriteBatch;
        }
        public void Update(string message)
        {
            batch.DrawString(spriteFont, message, Vector2.Zero, Color.White);
        }
    }
}