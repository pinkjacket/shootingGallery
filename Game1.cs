using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace shootingGallery
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D target;
        Texture2D crosshair;
        Texture2D background;

        SpriteFont gameFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            target = Content.Load<Texture2D>("bluetarget");
            crosshair = Content.Load<Texture2D>("greencross");
            background = Content.Load<Texture2D>("grayback");

            gameFont = Content.Load<SpriteFont>("galleryFont");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            spriteBatch.DrawString(gameFont, "Testing", new Vector2(100, 100), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
