using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Letalka
{
    public class GameContext : Game
    {
        private IGameState _state = StateFactory.GetState(typeof(Menu));
        public IGameState State {
            get
            {
                return _state;
            }
            set
            {
                _state.UnloadContent(this);
                value.Initialize(this);
                value.LoadContent(this);
                _state = value;
            }
        }
        public SpriteBatch SpriteBatch { get; set; }
        public int Width { get; } = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public int Height { get; } = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        public GameContext()
        {
            new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = Width,
                PreferredBackBufferHeight = Height,
                IsFullScreen = true
            }.ApplyChanges();
        }
        protected override void Initialize()
        {
            Content.RootDirectory = "Content";

            State.Initialize(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            State.LoadContent(this);
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            State.UnloadContent(this);
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            State.Update(this, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            State.Draw(this, gameTime);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
