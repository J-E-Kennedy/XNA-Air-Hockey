using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAAirHockey
{
    class Circle : Sprite
    {
        public float Radius { get; private set; }

        public new float Area => (float)Math.PI * Radius * Radius;
        public Vector2 Center => new Vector2(Position.X + Radius, Position.Y + Radius);

        /// <summary>
        /// Creates a equidistant sprite with circle hit detection.
        /// </summary>
        /// <param name="image">the image when the sprite is drawn</param>
        /// <param name="position">the position of the top-left corner of the sprite</param>
        /// <param name="radius">the circle's radius</param>
        /// <param name="color">the circle's tint</param>
        public Circle(Texture2D image, Vector2 position, float radius, Color color) : base(image, position, radius * 2, radius * 2, color)
        {
            Radius = radius;
        }

        /// <summary>
        /// Checks if two circles are overlapping.
        /// </summary>
        /// <param name="value">the circle to compare</param>
        /// <returns></returns>
        public bool Intersects(Circle value)
        {
            //If the sum of their radii exceeds the distance between their centers, if the radiii are larger the circles must be overlapping.
            return (Center - value.Center).Length() < Radius + value.Radius;
        }
        
        /// <summary>
        /// Stops a circle from exiting the bounds of a rectangle.
        /// </summary>
        /// <param name="bounds">the rectangle to keep the circle within</param>
        protected void keepWithinBounds(Rectangle bounds)
        {
            if(X < bounds.X)
            {
                Position = new Vector2(bounds.X, Y);
            }
            else if(X + Width > bounds.X + bounds.Width)
            {
                Position = new Vector2(bounds.Width - Width, Y);
            }
            if(Y < bounds.Y)
            {
                Position = new Vector2(X, bounds.Y);
            }
            else if(Y + Height > bounds.Y + bounds.Height)
            {
                Position = new Vector2(X, bounds.Height - Height);
            }
        }

    }
}
