using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAAirHockey
{
    class Sprite
    {
        Texture2D texture;
        Vector2 scale;
        public int X => (int)Position.X;
        public int Y => (int)Position.Y;
        public int Width => Hitbox.Width;
        public int Height => Hitbox.Height;
        public float Area => Hitbox.Width * Hitbox.Height;

        Color color;
        public Vector2 Position { get; set; }

        public Rectangle Hitbox => new Rectangle(X, Y, (int)(texture.Width * scale.X), (int)(texture.Height * scale.Y));

        /// <summary>
        /// Creates a sprite using the size of the image as it's in-game size.
        /// </summary>
        /// <param name="texture">the image when the sprite is drawn</param>
        /// <param name="location">the position of the top-left corner of the sprite</param>
        /// <param name="color">the sprite's tint</param>
        public Sprite(Texture2D texture, Rectangle location, Color color) 
            : this(texture, new Vector2(location.X, location.Y), location.Width, location.Height, color) { }

        /// <summary>
        /// Creates a sprite with a given width and height.
        /// </summary>
        /// <param name="texture">the image when the sprite is drawn</param>
        /// <param name="position">the position of the top-left corner of the sprite</param>
        /// <param name="width">the width of the sprite</param>
        /// <param name="height">the height of the sprite</param>
        /// <param name="color">the sprite's tint</param>
        public Sprite(Texture2D texture, Vector2 position, float width, float height, Color color)
        {
            this.texture = texture;
            this.color = color;
            Position = position;
            scale = new Vector2(width / texture.Width, height / texture.Height);
        }

        /// <summary>
        /// Draws the sprite to the screen.
        /// </summary>
        /// <param name="spriteBatch">the sprite batch to draw with</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Hitbox, color);
        }
    }
}
