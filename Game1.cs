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
        MouseState mouse;


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
            mouse = Mouse.GetState();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);
            spriteBatch.Begin();
            Grid();
            gate(new Vector2(100, 100), 2, 1, Color.Red);

            Line(new Vector2(mouse.X, mouse.Y), new Vector2(300, 300), 10, Color.Cyan);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        void Circle(Vector2 center, int radius, Color color)
        {
            for (double x = 0; x < radius * 2; x++)
            {
                for (double y = 0; y < radius * 2; y++)
                {
                    if (Math.Sqrt(Math.Pow(x - radius, 2) + Math.Pow(y - radius, 2)) < radius)
                    {
                        spriteBatch.Draw(pixel, new Rectangle((int)x + (int)center.X - radius, (int)y + (int)center.Y - radius, 1, 1), color);
                    }
                }
            }

        }
        void gate(Vector2 position, int inputs, int outputs, Color color){
            int size = 100;
            for (int i = 1; i < inputs + 1; i++)
            {
                spriteBatch.Draw(pixel, new Rectangle((int)(position.X - size / 2), (int)(position.Y + ((size * 2) / (inputs + 1)) * i), size, 2), Color.White);
            }
            for (int i = 1; i < outputs + 1; i++)
            {
                spriteBatch.Draw(pixel, new Rectangle((int)(position.X), (int)(position.Y + ((size * 2) / (outputs+1)) * i), (int)(size*2.5), 2), Color.White);
            }
            spriteBatch.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, size, size*2), color);
            Circle(new Vector2(position.X+size, position.Y+size), size, color);
        }
        void Line(Vector2 pos1, Vector2 pos2, int thickness, Color color) {
            float x = pos1.X - pos2.X;
            float y = pos1.Y - pos2.Y;
            float k = x / y;
            float k1 = pos2.Y / pos2.X;
            int r = (int)Math.Sqrt(x * x + y * y);
            double v = Math.Atan(-((pos1.X-pos2.X)/(pos1.Y-pos2.Y))) + (Math.PI / 2);
            //spriteBatch.Draw(pixel, new Rectangle((int)pos1.X, (int)pos1.Y, (int)pos2.X, (int)pos2.Y), Color.Black);
            Console.WriteLine(v);
            for (int i = 0; i < r; i++) {
                spriteBatch.Draw(pixel, new Rectangle((int)(i*Math.Cos(v)+pos2.X), (int)(i * Math.Sin(v)+pos2.Y), thickness, thickness), color);
            }
            
        }
        void Grid()
        {
            for(int y = 0; y < 720; y += 100) {
                for(int x = 0; x < 1280; x += 100) {
                    //Line(new Vector2(0, y), new Vector2(-1080, y), 1, Color.Black);
                    //Line(new Vector2(x, 0), new Vector2(x, -720), 1, Color.Black);
                    spriteBatch.Draw(pixel, new Rectangle(x, 0, 1, 720), Color.Black);
                    spriteBatch.Draw(pixel, new Rectangle(0, y, 1280, 1), Color.Black);
                    //spriteBatch.Draw(pixel, new Rectangle(x, y, 2, 1080), Color.Black);
                }
            }
        }
    }
}
