using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAAirHockey
{
    class PhysCircle : Circle
    {
        public Vector2 Velocity { get; protected set; }
        public float CoeffOfFriction { get; private set; }

        /// <summary>
        /// A circle that tracks it's velocity and has a coefficient of friction.
        /// </summary>
        /// <param name="image">the image when the sprite is drawn</param>
        /// <param name="position">the position of the top-left corner of the sprite</param>
        /// <param name="radius">the circle's radius</param>
        /// <param name="color">the circle's tint</param>
        /// <param name="coeffOfFriction">The amount the circle slows down by as it moves</param>
        public PhysCircle(Texture2D image, Vector2 position, float radius, Color color, float coeffOfFriction) : base(image, position, radius, color)
        {
            CoeffOfFriction = coeffOfFriction;
        }



    }
}
