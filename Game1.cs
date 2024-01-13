using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LogicSimulator
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;






        static bool Not(bool input) {
            return !input;
        }

        static bool And(bool input1, bool input2) {
            return input1 && input2;
        }
        
        static bool Nand(bool input1, bool input2) {
            return ! input1 && input2;
        }
        
        static bool Or(bool input1, bool input2) {
            return input1 || input2;
        }
        
        static bool Nor(bool input1, bool input2) {
            return !input1 || input2;
        }
        
        static bool Xor(bool input1, bool input2) {
            return (input1 || input2) && input1 != input2;
        }
        
        static bool Xnor(bool input1, bool input2) {
            return input1 == input2;
        }
        
        
        //Dessa kräver 3 inputs vilket blir svårare i simulationen

        static bool MUX(bool input1, bool input2, bool input3) {
            if(input3) {return input1;} else {return input2;}
        }
        
        //Följande har 2 outputs
        
        static (bool,bool) DEMUX(bool input1, bool input2) {
            if(input2) {return(input1, false);} else {return(false, input1);}
        }




        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
