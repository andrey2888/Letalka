using Microsoft.Xna.Framework;

namespace Letalka
{
    public interface IGameState
    {
        void Initialize(GameContext context);

        void LoadContent(GameContext context);

        void UnloadContent(GameContext context);

        void Update(GameContext context, GameTime gameTime);

        void Draw(GameContext context, GameTime gameTime);
    }
}
