using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.model;
using Game1.manager;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace Game1.Sprites
{
   public class Sprite 
    {

        #region Fields
         AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animation;

        protected Vector2 _position;

        protected Texture2D _texture;

        #endregion
        #region Properties
        public Input Input;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null )
                {
                    _animationManager.Position = _position;
                }

            }
        }
        public float Speed = 1f;
        public Vector2 Velocity;
        #endregion
#region Metod
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture,Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("This ain");
           
        }
        protected  virtual void Mover()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed;
            }
               
         else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = Speed;
            }
                 
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X = -Speed;
            }
                
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = Speed;
            }
                
        }
        protected virtual void SetAnimations()
        {
            if (Velocity.X > 0)
            {
                _animationManager.Play(_animation["WalkRight"]);
            }
            else if (Velocity.X < 0)
            {
                _animationManager.Play(_animation["WalkLeft"]);
            }
            else if (Velocity.Y > 0)
            {
                _animationManager.Play(_animation["WalkDown"]);
            }
            else if (Velocity.Y < 0)
            {
                _animationManager.Play(_animation["WalkUp"]);
            }
        }
        public Sprite(Dictionary<string,Animation> animations)
        {
            _animation = animations;
            _animationManager = new AnimationManager(_animation.First().Value);
        }
        
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }
        public virtual void Update(GameTime gametime, List<Sprite> sprites)
        {
            Mover();

            SetAnimations();

            _animationManager.Update(gametime);

            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        


        #endregion
    }
}
