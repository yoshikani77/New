using Game1.model;
using Game1.Sprites;
using Game1.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<Sprite> _sprites;
        private State _currentState;
        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }


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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this, GraphicsDevice, Content);




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
            if(_nextState != null)
            {
                _currentState = _nextState;

                _nextState  = null;
            }


            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);


           
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _currentState.Draw(gameTime, spriteBatch);





            

            base.Draw(gameTime);
        }
    }
}
