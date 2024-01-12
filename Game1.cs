using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace LogicSimulator
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Texture2D pixel;
        Rectangle rect;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
            //Head = Content.Load<SpriteFont>("head");
            //Text = Content.Load<SpriteFont>("text");
            rect = new Rectangle(200, 100, 100, 100);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, rect, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void Circle(Vector2 centre, int radius, Color color)
        {
            for (double x = 0; x < radius * 2; x++)
            {
                for (double y = 0; y < radius * 2; y++)
                {
                    if (Math.Sqrt(Math.Pow(x - radius, 2) + Math.Pow(y - radius, 2)) < radius)
                    {
                        spriteBatch.Draw(pixel, new Rectangle((int)x + (int)centre.X - radius, (int)y + (int)centre.Y - radius, 1, 1), color);
                    }
                }
            }

        }
    }
}
