using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAAirHockey
{
    class Goal : Sprite
    {
        float containmentNeeded;

        /// <summary>
        /// Creates an air hockey goal location.
        /// </summary>
        /// <param name="texture">the image when the sprite is drawn</param>
        /// <param name="location">the position of the top-left corner of the sprite</param>
        /// <param name="color">the sprite's tint</param>
        /// <param name="containmentNeeded">the amount of overlap of the puck and goal needed to score a point as a value between .01 and 1</param>
        public Goal(Texture2D texture, Rectangle location, Color color) : base(texture, location, color){}

        /// <summary>
        /// Checks if a goal contains enough of the puck to score a goal, and if so resets the puck.
        /// </summary>
        /// <param name="puck">the puck to check</param>
        public void Contains(Puck puck)
        {
            Rectangle overlap = Rectangle.Intersect(Hitbox, puck.Hitbox);
            int OverlapArea = overlap.Width * overlap.Height;
            if (OverlapArea > puck.Area)
            {
                puck.Reset();
            }
        }

    }
}
