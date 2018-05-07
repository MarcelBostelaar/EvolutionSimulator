using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace EvolutionSimulator
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            if(!(graphics.PreferredBackBufferWidth == Window.ClientBounds.Width && graphics.PreferredBackBufferHeight == Window.ClientBounds.Height)){
                graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
                graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
                graphics.ApplyChanges();
            }
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.IsMouseVisible = true;
            this.Window.AllowUserResizing = true;
            this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
        }
        SpriteFont FontDefault;
        Texture2D SingleWhitePixel;
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            FontDefault = Content.Load<SpriteFont>("DefaultFont");
            SingleWhitePixel = new Texture2D(GraphicsDevice, 1, 1);
            SingleWhitePixel.SetData(new Color[]{ Color.White});
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.End();

            base.Draw(gameTime);
        }


        const int spacing = 40;
        private void DrawBoard()
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            spriteBatch.End();
        }
    }
}
