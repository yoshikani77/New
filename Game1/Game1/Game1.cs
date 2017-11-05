using Game1.Controls;
using Game1.model;
using Game1.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Color _backgroundColor = Color.CornflowerBlue;

        private List<Component> _gameComponets;

        private List<Sprite> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);//????

            var randomButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(250,200),
                Text = "Random",
            };

            randomButton.Click += RandomButton_Click;

            // spriteBatch = new SpriteBatch(GraphicsDevice);//????

            var quitButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(250,250),
                Text = "Quit",
            };

            quitButton.Click += QuitButton_Click;
           

            _gameComponets = new List<Component>()
            {
                randomButton,
                quitButton,
                
            };  




            /*

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var animation = new Dictionary<string, Animation>()
            {
                { "WalklUp", new Animation(Content.Load<Texture2D>("Player/WalkingUp"),3) },
                { "WalkDown", new Animation(Content.Load<Texture2D>("Player/WalkingDown"),3) },
                { "WalkLeft", new Animation(Content.Load<Texture2D>("Player/WalkingLeft"),3) },
                { "WalkRight", new Animation(Content.Load<Texture2D>("Player/WalkingRight"),3) },
            };

            _sprites = new List<Sprite>()
            {
                new Sprite(animation)
                {
                    Position = new Vector2(100,100),
                    Input =new Input()
                    {
                    Up =Keys.W,
                    Down =Keys.S,
                    Left= Keys.A,
                    Right = Keys.D,
                    },
                },


               





                 new Sprite(new Dictionary<string, Animation>()
            {
                { "WalkUp", new Animation(Content.Load<Texture2D>("Player/WalkingUp"),3) },
                { "WalkDown", new Animation(Content.Load<Texture2D>("Player/WalkingDown"),3) },
                { "WalkLeft", new Animation(Content.Load<Texture2D>("Player/WalkingLeft"),3) },
                { "WalkRight", new Animation(Content.Load<Texture2D>("Player/WalkingRight"),3) },
            })
            {
                    Position = new Vector2(150,100),
                    Input =new Input()
                    {
                    Up =Keys.Up,
                    Down =Keys.Down,
                    Left= Keys.Left,
                    Right = Keys.Right,
                    }
                }
            };

            */
        }
        private void RandomButton_Click(object sender, System.EventArgs e)
        {
            var random = new Random();

            _backgroundColor = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            foreach (var component in _gameComponets)
                component.Update(gameTime);

            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColor);

            spriteBatch.Begin();

            foreach (var component in _gameComponets)
               component.Draw(gameTime,spriteBatch);



            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
