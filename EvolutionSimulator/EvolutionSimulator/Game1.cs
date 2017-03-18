using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        
        protected override void Initialize()
        {
            base.Initialize();
            GameWorld = new World(100, 0);
            update = new GameUpdate(GameWorld, this);
            update.StartThread();
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
        World GameWorld;
        GameUpdate update;
        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
            {
                update.StartThread();
            }
            if (state.IsKeyDown(Keys.S))
            {
                update.StopThread();
            }
            if (state.IsKeyDown(Keys.Z))
            {
                update.StartThread(1000);
            }
            update.Invoke();
            base.Update(gameTime);
        }
        const int spacing = 40;
        protected override void Draw(GameTime gameTime)
        {
            update.incrementFramtick();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            for (int x = 0; x < GameWorld.size; x++)
            {
                for (int y = 0; y < GameWorld.size; y++)
                {
                    spriteBatch.Draw(SingleWhitePixel, new Rectangle(new Point(x * spacing, y * spacing), new Point(spacing)), GameWorld.GetTile(x, y).getColor(update.UpdateTick));
                    spriteBatch.DrawString(FontDefault, GameWorld.GetTile(x, y).food.ToString(), new Vector2(x * spacing, y * spacing), Color.Black);
                }
            }
            spriteBatch.Draw(SingleWhitePixel, new Rectangle(0, 0, 200, 200), Color.White);
            spriteBatch.DrawString(FontDefault, "Update #" + update.UpdateTick, Vector2.Zero, Color.Black);
            spriteBatch.DrawString(FontDefault, "Frame #" + update.FrameTick, new Vector2(0, 20), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
