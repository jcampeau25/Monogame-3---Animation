using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Monogame_3___Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D tribbleGreyTexture, tribbleCreamTexture, tribbleBrownTexture, tribbleOrangeTexture, spaceTexture;

        Rectangle tribbleGreyRect, tribbleCreamRect, tribbleBrownRect, tribbleOrangeRect, backgroundRect;

        Vector2 tribbleGreySpeed, tribbleBrownSpeed, tribbleOrangeSpeed, tribbleCreamSpeed;

    
        Random generator = new Random();

        Color tribbleColour = Color.White;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            window = new Rectangle(0, 0, 800, 600);
            tribbleGreyRect = new Rectangle(300, 10, 100, 100);
            tribbleGreySpeed = new Vector2(2, 2);
            tribbleBrownRect = new Rectangle(10, 400, 100, 100);
            tribbleBrownSpeed = new Vector2(7, 3);
            tribbleCreamRect = new Rectangle(400, 400, 100, 100);
            tribbleCreamSpeed = new Vector2(3, 0);
            tribbleOrangeRect = new Rectangle(20, 200, 100, 100);
            tribbleOrangeSpeed = new Vector2(4, 4);
            
            backgroundRect = new Rectangle(0, 0, 800, 600);

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            spaceTexture = Content.Load<Texture2D>("space");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            if (tribbleGreyRect.Right > window.Width || tribbleGreyRect.Left < 0)
            {
                tribbleGreySpeed.X *= -1;
                tribbleColour = new Color(generator.Next(1, 256), generator.Next(1, 256), generator.Next(1, 256));
            }
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGreyRect.Bottom > window.Height || tribbleGreyRect.Top < 0)
            {
                tribbleGreySpeed.Y *= -1;
                tribbleColour = new Color(generator.Next(1, 256), generator.Next(1, 256), generator.Next(1, 256));
            }

                tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            if (tribbleBrownRect.Right > window.Width || tribbleBrownRect.Left < 0)
                tribbleBrownSpeed.X *= -1;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
            if (tribbleBrownRect.Bottom > window.Height || tribbleBrownRect.Top < 0)
                tribbleBrownSpeed.Y *= -1;

            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            if (tribbleCreamRect.Left > window.Width)
                tribbleCreamRect.X = -100;

            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            if (tribbleOrangeRect.Right > window.Width || tribbleOrangeRect.Left < 0)
                tribbleOrangeSpeed.X *= -1;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            if (tribbleOrangeRect.Bottom > window.Height || tribbleOrangeRect.Top < 0)
                tribbleOrangeSpeed.Y *= -1;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(spaceTexture, backgroundRect, Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, tribbleColour);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
