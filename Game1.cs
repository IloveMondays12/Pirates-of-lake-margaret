using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        Texture2D windowScreen, pirateShip, lewisHappy, lewisSad, raihanOpen, raihanClosed, introBg, mainBg, outroBg;
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
            pirateShip = Content.Load<Texture2D>("pirateShipLewis");
            lewisHappy = Content.Load<Texture2D>("Lake Margerat");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.Intro)
            {
                windowScreen = introBg;
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.MainAnimation;
            }
            if (screen == Screen.MainAnimation)
            {
                windowScreen = mainBg;
                //if (mouseState.LeftButton == ButtonState.Pressed)
                //    screen = Screen.MainAnimation
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(windowScreen, window, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}