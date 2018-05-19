using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Letalka
{
    class DebugString
    {
        static SpriteFont spriteFont;
        public static void LoadContent(ContentManager content)
        {
           spriteFont = content.Load<SpriteFont>("Font");
        }
        public static String toPrint = "";
        public static void Draw(SpriteBatch batch) {
            batch.DrawString(spriteFont, toPrint, Vector2.Zero, Color.White);
        }
    }
}
