using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pirates_of_lake_margaret
{
    
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        enum Screen
        {
            Intro,
            MainAnimation,
            Outro
        }
        MouseState mouseState;
        Screen screen;
        Rectangle Raihan, ship, lewis, window;
        Texture2D windowScreen, pirateShip, lewisHappy, lewisSad, raihanOpen, raihanClosed, raihanChewing, introBg, mainBg, outroBg;
        Vector2 raihanSpeed, lewisSpeed;
        bool eaten = false;
        SoundEffect Chewing, cry;
        SoundEffectInstance ChewingInstance, criedInstance;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0,0,800,600);
            Raihan = new Rectangle(800,270,100,10);
            ship = new Rectangle(100, 240, 70, 70);
            lewis = new Rectangle(100, 270, 100, 100);
            raihanSpeed = Vector2.Zero;
            lewisSpeed = Vector2.Zero;
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            screen = Screen.Intro;
            ChewingInstance = Chewing.CreateInstance();
            criedInstance = cry.CreateInstance();
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            introBg = Content.Load<Texture2D>("Jungle lake margerat");
            mainBg = Content.Load<Texture2D>("Lake Margerat");
            pirateShip = Content.Load<Texture2D>("pirateShipLewis");
            lewisHappy = Content.Load<Texture2D>("Lewis Cruisin");
            raihanClosed = Content.Load<Texture2D>("Raihan cold");
            raihanOpen = Content.Load<Texture2D>("Raihan open mouth");
            raihanChewing = Content.Load<Texture2D>("Raihan chewing");
            Chewing = Content.Load<SoundEffect>("Chewing (carder)");
            cry = Content.Load<SoundEffect>("Help me (lewis)");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.Intro)
            {
                mouseState = Mouse.GetState();
                windowScreen = introBg;
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.MainAnimation;
            }
            if (screen == Screen.MainAnimation)
            {
                windowScreen = mainBg;
                if (Raihan.Left <= ship.Right && eaten == false)
                {
                    raihanSpeed.X *= -1;
                    lewisSpeed.X *= -1;
                }
                else if (eaten == false && )
                else if ()
                {

                }
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(windowScreen, window, Color.White);
            if (screen == Screen.MainAnimation)
            {

            }
                _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}