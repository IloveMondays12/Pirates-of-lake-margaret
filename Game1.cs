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
        SpriteFont introText, outroText;
        bool eaten = false;
        SoundEffect Chewing, cry;
        SoundEffectInstance ChewingInstance, criedInstance;
        int eatTime = 0;
            float textFade = 0;
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
            Raihan = new Rectangle(800,370,100,10);
            ship = new Rectangle(100, 300, 100, 100);
            lewis = new Rectangle(120, 270, 90, 90);
            raihanSpeed = new Vector2 (-1,0);
            lewisSpeed = new Vector2 (1,0);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            screen = Screen.Intro;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            introBg = Content.Load<Texture2D>("Jungle lake margerat");
            mainBg = Content.Load<Texture2D>("Lake Margerat");
            outroBg = Content.Load<Texture2D>("haunted cave");
            pirateShip = Content.Load<Texture2D>("pirateShipLewis");
            lewisHappy = Content.Load<Texture2D>("Lewis Cruisin");
            lewisSad = Content.Load<Texture2D>("scaredLewis");
            raihanClosed = Content.Load<Texture2D>("Raihan cold");
            raihanOpen = Content.Load<Texture2D>("Raihan open mouth");
            raihanChewing = Content.Load<Texture2D>("Raihan chewing");
            Chewing = Content.Load<SoundEffect>("Chewing (carder)");
            cry = Content.Load<SoundEffect>("Help me (lewis)");
            introText = Content.Load<SpriteFont>("File");
            outroText = Content.Load<SpriteFont>("outroText");
            ChewingInstance = Chewing.CreateInstance();
            criedInstance = cry.CreateInstance();

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
                if (raihanSpeed.X == -1 && Raihan.Height < 100)
                {
                    raihanSpeed.Y = -1;
                    Raihan.Height += 1;
                }
                else if (raihanSpeed.X == -1 && Raihan.Height == 100)
                {
                    raihanSpeed.Y = 0;
                }
                if (Raihan.Intersects(lewis) && eaten == false)
                {
                    raihanSpeed.X *= 0;
                    lewisSpeed.X *= 0;
                    if (eatTime == 15)
                    {
                        eaten = true;
                        ChewingInstance.Play();
                    }
                    eatTime++;
                }
                if (Raihan.Intersects(lewis) && ChewingInstance.State == SoundState.Stopped && eaten == true)
                {
                    raihanSpeed.X = 1;
                    lewisSpeed.X = -2;
                    criedInstance.Play();
                }
                if (lewis.X <= -90)
                {
                    screen = Screen.Outro;
                }
                Raihan.X += (int)raihanSpeed.X;
                Raihan.Y += (int)raihanSpeed.Y;
                lewis.X += (int)lewisSpeed.X;
                lewis.Y += (int)lewisSpeed.Y;
                ship.X += (int)lewisSpeed.X;
                ship.Y += (int)lewisSpeed.Y;
                
            }
            if (screen == Screen.Outro)
            {
                windowScreen = outroBg;
                textFade++;
                if (textFade == 300f)
                {
                    Exit();
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
            if (screen == Screen.Intro) 
            {
                _spriteBatch.DrawString(introText, ("Welcome to the wonderful \nLake Margerat ..."), new Vector2(100, 300), Color.White);
            }
            if (screen == Screen.MainAnimation)
            {
                if (eaten == false && !Raihan.Intersects(lewis)) 
                {
                    _spriteBatch.Draw(raihanClosed, Raihan, Color.White);
                    _spriteBatch.Draw(lewisHappy, lewis, Color.White);
                    _spriteBatch.Draw(pirateShip, ship, Color.White);
                }
                else if (Raihan.Intersects(lewis) && eaten == false)
                {
                    _spriteBatch.Draw(raihanOpen, Raihan, Color.White);
                    _spriteBatch.Draw(lewisHappy, lewis, Color.White);
                    _spriteBatch.Draw(pirateShip, ship, Color.White);
                }
                   else  if (eaten == true && ChewingInstance.State == SoundState.Playing)
                {
                    _spriteBatch.Draw(raihanChewing, Raihan, Color.White);
                }
                if (eaten == true && ChewingInstance.State == SoundState.Stopped)
                {
                    _spriteBatch.Draw(raihanClosed, Raihan, Color.White);
                    _spriteBatch.Draw(lewisSad,lewis, Color.White);
                }
            }
            if (screen == Screen.Outro)
            {
                _spriteBatch.DrawString(outroText, ("Raihan returned to his bog \nwaiting for his\n next victims ..."), new Vector2(220, 160), Color.Brown * ((100f-(textFade/3f))/100f));
            }
                _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}