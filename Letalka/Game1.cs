using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace Letalka
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        PlayerShip playerShip;
        Texture2D backgroundTexture;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Spaceship spaceship;
        LTH playerLTH;
        LTH compLTH;
        World world;
        GunType pulemet;
        Texture2D pulemetTex;

        Menu menu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            menu = new Menu();
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
            playerLTH = new LTH(0.1f,0.1f,0.03f,0.0005f,50,75);
            compLTH = new LTH(0.1f, 0.05f, 0.03f, 0.0005f, 50, 75);
            pulemetTex = Content.Load<Texture2D>("projectiles/bullet1");
            Bullet pulemetBullet = new Bullet(Vector2.Zero, 7f, 10, 5, pulemetTex);
            pulemet = new GunType(0.1f, 7f, 20f, pulemetBullet);
            Texture2D plasmaTex = Content.Load<Texture2D>("projectiles/bullet2");
            Bullet plasmaBullet = new Bullet(Vector2.Zero, 100f, 30, 15, plasmaTex,solid:true);
            GunType plasmamet = new GunType(1f, 7f, 5f, plasmaBullet);
            Bullet magnetBullet = new MagnetBullet(Vector2.Zero, 5f, 10, 10, plasmaTex);
            GunType magnetmet = new GunType(0.03f, 7f, 25f, magnetBullet, 0.3f);
            spaceship = new Spaceship(Content.Load<Texture2D>("space/s2"),playerLTH,playerPosition,0.0f);
            spaceship.AddGun(magnetmet, new Vector2(0f,  20f));
            spaceship.AddGun(magnetmet, new Vector2(0f, -20f));
            spaceship.AddGun(magnetmet, new Vector2(40f, 15f));
            spaceship.AddGun(magnetmet, new Vector2(40f, -15f));
            //spaceship.AddGun(magnetmet, new Vector2(40f, 0f));
            playerShip = new PlayerShip(spaceship);
            world.playerShip = spaceship;
            world.players.Add(playerShip);
            Spaceship[] spaceship2 = new Spaceship[10];
            for (int i = 0; i < 5; i++)
            {
                spaceship2[i] = new Spaceship(Content.Load<Texture2D>("space/vs1"), compLTH, playerPosition + new Vector2(1000, -500), 0.0f);
                spaceship2[i].speed = Vector2Extension.Rotate(Vector2.UnitX, i);
                //spaceship2[i].angularSpeed = 0.0f;
                spaceship2[i].angle = (float)-Math.PI/2;
                spaceship2[i].AddGun(pulemet, new Vector2(20f, 0f));
                
                world.AddObject(spaceship2[i]);
                world.players.Add(new ComputerShip(spaceship2[i]));
            }
            world.AddObject(spaceship);
            
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
            backgroundTexture = Content.Load<Texture2D>("space/5");
            DebugString.LoadContent(Content);
            menu.LoadContent(Content);



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
            //playerShip.Update(gameTime);
            world.Update(gameTime);

            menu.Update(gameTime);


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
            world.Draw(spriteBatch);
            DebugString.Draw(spriteBatch);


            menu.Draw(spriteBatch);



            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
