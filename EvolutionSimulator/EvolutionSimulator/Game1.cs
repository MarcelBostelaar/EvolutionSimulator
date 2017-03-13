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
        }
        SpriteFont FontDefault;
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            FontDefault = Content.Load<SpriteFont>("DefaultFont");
        }
        protected override void UnloadContent()
        {
        }
        GameUpdate update = new GameUpdate();
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
            update.Invoke();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            update.incrementFramtick();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(FontDefault, "Update #" + update.UpdateTick, Vector2.Zero, Color.White);
            spriteBatch.DrawString(FontDefault, "Frame #" + update.FrameTick, new Vector2(0, 20), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
