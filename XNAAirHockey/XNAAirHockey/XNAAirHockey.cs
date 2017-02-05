using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNAAirHockey
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class XNAAirHockey : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Puck puck;
        Paddle paddle;
        Paddle compPaddle;
        Sprite seperator;
        Goal leftGoal;
        Goal rightGoal;
        SpriteFont font;
        List<Sprite> drawList;
        Rectangle screen;
        Vector2 screenCenter;
        public XNAAirHockey()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 720;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            drawList = new List<Sprite>();
            Texture2D circleTexture = Content.Load<Texture2D>("bigCircle");
            Texture2D rectangleTexture = Content.Load<Texture2D>("Box");
            font = Content.Load<SpriteFont>("debugFont");
            screen = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            screenCenter = new Vector2(screen.Width, screen.Height) / 2;
            leftGoal = new Goal(rectangleTexture, new Rectangle(-50, 200, 175, 250), Color.Blue);
            rightGoal = new Goal(rectangleTexture, new Rectangle(screen.Width - 125, 200, 175, 250), Color.Red);
            seperator = new Sprite(rectangleTexture, new Rectangle((int)screenCenter.X - 10, 0, 20, screen.Height), Color.Black);
            int puckSize = 40;
            puck = new Puck(circleTexture, screenCenter - new Vector2(puckSize), puckSize, Color.Black, 0.01f);
            paddle = new Paddle(circleTexture, new Vector2(400), 60, Color.Blue, 5,  
                new Rectangle(0, 0, (int)screenCenter.X, screen.Height), true);
            compPaddle = new Paddle(circleTexture, new Vector2(850, 250), 60, Color.Red, 5, 
                new Rectangle((int)screenCenter.X, 0, (int)screenCenter.X, screen.Height) ,false);
            drawList.Add(leftGoal);
            drawList.Add(rightGoal);
            drawList.Add(seperator);
            drawList.Add(puck);
            drawList.Add(paddle);
            drawList.Add(compPaddle);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            InputManager.mouseState = Mouse.GetState();
            InputManager.keyboardState = Keyboard.GetState();
            if(InputManager.keyboardState.IsKeyDown(Keys.R))
            {
                puck.Reset();
            }
            puck.paddleCollision(paddle);
            puck.paddleCollision(compPaddle);
            puck.bounceWithinBounds(screen);
            paddle.Update(gameTime);
            puck.Update(gameTime);
            leftGoal.Contains(puck);
            rightGoal.Contains(puck);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach(var item in drawList)
            {
                item.Draw(spriteBatch);
            }
            spriteBatch.DrawString(font, paddle.Velocity.ToString(), Vector2.Zero, Color.Pink);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
