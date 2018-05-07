using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Letalka
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Texture2D backgroundTexture;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Spaceship spaceship;
        Spaceship spaceship2;
        PlayerShip playerShip;
        LTH playerLTH;
        World world;
        GunType pulemet;
        Texture2D pulemetTex;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            world = World.getInstance();
            int Width  = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            graphics.PreferredBackBufferWidth  = Width;
            graphics.PreferredBackBufferHeight = Height;

            world.Height = Height;
            world.Width = Width;

            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);//dich
            playerLTH = new LTH(0.05f,0.025f,0.015f,0.00025f,50,75);
            pulemetTex = Content.Load<Texture2D>("projectiles/bullet1");
            pulemet = new GunType(0.1f, 0.0f, 20f, pulemetTex);
            spaceship = new Spaceship(Content.Load<Texture2D>("space/vs2"),playerLTH,playerPosition,0.0f);
            spaceship.AddGun(pulemet, new Vector2(0f,  20f));
            spaceship.AddGun(pulemet, new Vector2(0f, -20f));
            spaceship2 = new Spaceship(Content.Load<Texture2D>("space/vs1"), playerLTH, playerPosition + new Vector2(500,0), 0.0f);

            spaceship2.speed = Vector2.UnitX;
            spaceship2.angularSpeed = 0.03f;
            playerShip = new PlayerShip(spaceship);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("space/4");
           

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            playerShip.Update(gameTime);
            spaceship.Update(gameTime);
            spaceship2.Update(gameTime);
            world.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            float ratio = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / (float)backgroundTexture.Width;
            spriteBatch.Draw(backgroundTexture, Vector2.Zero, null, Color.White, 0.0f, Vector2.Zero, ratio , SpriteEffects.None, 1.0f);
            spaceship.Draw(spriteBatch);
            spaceship2.Draw(spriteBatch);
            world.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
