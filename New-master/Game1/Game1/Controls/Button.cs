using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Controls
{
   public class Button : Component
    {
        #region Fields
        private MouseState _currentMouse;

        private MouseState _previousMouse;

        private SpriteFont _font;

        private bool _isHavering;

        private Texture2D _texture;
        private Texture2D texture2D;
        private SpriteFont spriteFont;
        private SpriteFont font;



        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color Pencolour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {

                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public string Text { get; set; }

        #endregion
        #region Methods
        public Button(Texture2D texture, SpriteBatch spriteBatch)
        {
            _texture = texture;
            _font = spriteFont;

            Pencolour = Color.Black;

        }

        public Button(Texture2D texture2D, SpriteFont spriteFont)
        {
            this.texture2D = texture2D;
            this.spriteFont = spriteFont;
        }

        public override void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            var color = Color.White;

            if (_isHavering)
                color = Color.Gray;
            spriteBatch.Draw(_texture, Rectangle, color);

            if (string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).X / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), Pencolour);
            }
        }
        public override void Update(GameTime gametime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHavering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHavering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }

            }
        }
        #endregion
    }
}
