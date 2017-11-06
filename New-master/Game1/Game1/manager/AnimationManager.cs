using Game1.model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.manager
{
    class AnimationManager
    {
        private Animation _animation;

        private float _timer;
        public Vector2 Position { get; set; }
         
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_animation.Texture,Position,
                new Rectangle(_animation.CurrentFrame * _animation.FrameWideth,
                0, _animation.FrameWideth,
                _animation.FrameHeight),
                Color.White);

        }
      
        public AnimationManager(Animation animetion)
        {
            _animation = animetion;
        }

        public void Play(Animation animetion)
        {
            if (_animation == animetion)
                return;

            _animation = animetion;

            _animation.CurrentFrame = 0;

            _timer = 0;

        }

        public void Stop()
        {
            _timer = 0f;

            _animation.CurrentFrame = 0;
        }
        public void Update(GameTime gametime)
        {
            _timer += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (_timer > _animation.FrameSpeed) {
                _timer = 0f;
                _animation.CurrentFrame++;
                if (_animation.CurrentFrame >= _animation.FrameCount)
                    _animation.CurrentFrame = 0;


            }
        }
            
    }
}
