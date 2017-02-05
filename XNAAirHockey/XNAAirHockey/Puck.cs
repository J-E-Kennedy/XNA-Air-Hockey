using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAAirHockey
{
    class Puck : PhysCircle
    {
        //The location the paddle starts in and resets to after going into a goal.
        Vector2 startPosition;

        /// <summary>
        /// Creates an Air Hockey Puck.
        /// </summary>
        /// <param name="image">the image when the sprite is drawn</param>
        /// <param name="position">the position of the top-left corner of the sprite</param>
        /// <param name="radius">the puck's radius</param>
        /// <param name="color">the sprite's tint</param>
        /// <param name="coeffOfFriction">How much the puck slows down each update</param>
        public Puck(Texture2D image, Vector2 position, float radius, Color color, float coeffOfFriction) 
            : base(image, position, radius, color, coeffOfFriction)
        {
            startPosition = position;
        }
        /// <summary>
        /// Bounces the ball off an intersecting paddle.
        /// </summary>
        /// <param name="paddle">the paddle to check for an intersection</param>
        /// <returns>if the puck intersected the paddle</returns>
        public bool paddleCollision(Paddle paddle)
        {
            if(paddle.Intersects(this))
            {
                //adds the paddle's current velocity to the puck's velocity.
                Velocity += paddle.Velocity;
                //Normalizing the differences of the puck and paddle centers finds direction of the contact between them as a unit vector
                //We multiply this by the length of the old velocity length to set it's velocity into the new direction.
                Velocity = Vector2.Normalize(Center - paddle.Center) * Velocity.Length();
                return true;
            }
            return false;
        }


        /// <summary>
        /// Bounces the circle within a containing rectangle.
        /// </summary>
        /// <param name="bounds">the rectangle to bounce within</param>
        public void bounceWithinBounds(Rectangle bounds)
        {
            if(!bounds.Contains(Hitbox))
            {
                //The ball loses energy as it bounces off the bounds, I'm arbitralily using it's friction * 10 to represent this.
                Velocity *= 1 - CoeffOfFriction * 10;
                if (bounds.X > X)
                {
                    Velocity = new Vector2(Math.Abs(Velocity.X), Velocity.Y);
                }
                else if (bounds.Width + bounds.X < X + Width)
                {
                    Velocity = new Vector2(-Math.Abs(Velocity.X), Velocity.Y);
                }
                if (bounds.Y > Y)
                {
                    Velocity = new Vector2(Velocity.X, Math.Abs(Velocity.Y));
                }
                else if (bounds.Y + bounds.Height < Y + Height)
                {
                    Velocity = new Vector2(Velocity.X, -Math.Abs(Velocity.Y));
                }
                keepWithinBounds(bounds);
            }
        }

        /// <summary>
        /// Updates the pucks state in the game, moving it and slowing it down.
        /// </summary>
        /// <param name="gameTime">The game's current gameTime</param>
        public void Update(GameTime gameTime)
        {
            //Moves the puck's current position by it's velocity.
            Position += Velocity;
            //Slows the puck down based on it's friction coefficent.
            Velocity *= 1 - CoeffOfFriction;
        }

        /// <summary>
        /// Resets the puck back to it's starting position and sets it's velocity to zero.
        /// </summary>
        public void Reset()
        {
            Position = startPosition;
            Velocity = Vector2.Zero;
        }
    }
}
