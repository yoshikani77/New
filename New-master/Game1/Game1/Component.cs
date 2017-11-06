using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
   public abstract  class Component
    {
        public abstract void Draw(GameTime gametime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gametime);

/*
        internal void Draw(object gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        internal void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        */
    }
}
