using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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

        Vector2 targetPosition = new Vector2(300, 300);
        const int TARGET_RADIUS = 45;
        const int CROSS_RADIUS = 25;

        MouseState mState;
        bool mReleased = true;
        float mouseTargetDistance;

        int score = 0;
        float timer = 20f;

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
            background = Content.Load<Texture2D>("grayback2");

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

            if (timer > 0)
            {
                timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            mState = Mouse.GetState();

            mouseTargetDistance = Vector2.Distance(targetPosition, new Vector2(mState.X, mState.Y));

            if (mState.LeftButton == ButtonState.Pressed && mReleased == true)
            {
                if (mouseTargetDistance < TARGET_RADIUS && timer > 0)
                {
                    score++;

                    Random rand = new Random();

                    targetPosition.X = rand.Next(TARGET_RADIUS, graphics.PreferredBackBufferWidth - TARGET_RADIUS + 1);
                    targetPosition.Y = rand.Next(TARGET_RADIUS, graphics.PreferredBackBufferHeight - TARGET_RADIUS + 1);
                }

                mReleased = false;
            }

            if (mState.LeftButton == ButtonState.Released)
            {
                mReleased = true;
            }

            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            if (timer > 0)
            {
                spriteBatch.Draw(target, new Vector2(targetPosition.X - TARGET_RADIUS, targetPosition.Y - TARGET_RADIUS), Color.White);
            }

            spriteBatch.DrawString(gameFont, "Score: " + score.ToString(), new Vector2(3, 3), Color.White);
            spriteBatch.DrawString(gameFont, "Time: " + Math.Ceiling(timer).ToString(), new Vector2(3, 40), Color.White);

            spriteBatch.Draw(crosshair, new Vector2(mState.X - CROSS_RADIUS, mState.Y - CROSS_RADIUS), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
