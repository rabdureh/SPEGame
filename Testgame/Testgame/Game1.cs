
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

namespace Testgame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Card[] cards;
        KeyboardState oldState;
        Screen gameplay;
        Drawable background;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1024;
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
            base.IsMouseVisible = true;
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
            background = new Drawable()
            {
                attributes = new Attributes()
                {
                    texture = this.Content.Load<Texture2D>("PossibleBackground"),
                    color = Color.White,
                    position = new Vector2(512, 400),
                    depth = 1,
                    height = 802,
                    width = 1026,
                    rotation = 0
                }
            };

            gameplay = new Screen(background);

            // TODO: use this.Content to load your game content here
            
            cards = new Card[13];
            cards[0] = new Card(0, this.Content.Load<Texture2D>("AceHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[1] = new Card(1, this.Content.Load<Texture2D>("KingHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[2] = new Card(2, this.Content.Load<Texture2D>("TwoHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[3] = new Card(3, this.Content.Load<Texture2D>("ThreeHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[4] = new Card(4, this.Content.Load<Texture2D>("FourHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[5] = new Card(5, this.Content.Load<Texture2D>("FiveHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[6] = new Card(6, this.Content.Load<Texture2D>("SixHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[7] = new Card(7, this.Content.Load<Texture2D>("SevenHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[8] = new Card(8, this.Content.Load<Texture2D>("EightHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[9] = new Card(9, this.Content.Load<Texture2D>("NineHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[10] = new Card(10, this.Content.Load<Texture2D>("TenHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[11] = new Card(11, this.Content.Load<Texture2D>("JackHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);
            cards[12]= new Card(12, this.Content.Load<Texture2D>("QueenHearts"), this.Content.Load<Texture2D>("AceSpades"), new Vector2(100, 100), true);

            for (int i = 0; i < cards.Length; i++)
            {
                gameplay.Add(cards[i]);
            }

        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            // TODO: Add your update logic here
            KeyUpdate();

            gameplay.Update(gameTime);
            base.Update(gameTime);
        }


        protected void KeyUpdate()
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Up))
            {
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    Commands.Shuffle(cards);
                    Commands.MakePile(cards, new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
                }
            }

            if (newState.IsKeyDown(Keys.Down))
            {
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    Commands.MakePile(cards, new Vector2(300, 300));
                }
            }

            if (newState.IsKeyDown(Keys.A))
            {
                if (!oldState.IsKeyDown(Keys.A))
                {
                    Commands.MakePile(cards, new Vector2(300, 300));
                }
            }

            if (newState.IsKeyDown(Keys.A))
            {
                if (!oldState.IsKeyDown(Keys.A))
                {
                    Commands.MakePile(cards, new Vector2(300, 300));
                }
            }

            if (newState.IsKeyDown(Keys.W))
            {
                if (!oldState.IsKeyDown(Keys.W))
                {
                    Commands.MakePile(cards, new Vector2(300, 300));
                }
            }

            if (newState.IsKeyDown(Keys.S))
            {
                if (!oldState.IsKeyDown(Keys.S))
                {
                    Commands.MakePile(cards, new Vector2(300, 300));
                }
            }

            if (newState.IsKeyDown(Keys.A))
            {
                if (!oldState.IsKeyDown(Keys.A))
                {
                    Commands.MakePile(cards, new Vector2(300, 300));
                }
            }

            if (newState.IsKeyDown(Keys.F))
            {
                if (!oldState.IsKeyDown(Keys.F))
                {
                    graphics.IsFullScreen = true;
                    graphics.ApplyChanges();
                }
            }

            if (newState.IsKeyDown(Keys.Escape))
            {
                if (!oldState.IsKeyDown(Keys.Escape))
                {
                    graphics.IsFullScreen = false;
                    graphics.ApplyChanges();
                }
            }

            oldState = newState;
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, null);
            gameplay.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

