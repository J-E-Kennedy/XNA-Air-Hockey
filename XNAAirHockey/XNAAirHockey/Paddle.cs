using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAAirHockey
{
    class Paddle : PhysCircle
    {

        Vector2 lastPosition;
        int precision;
        Vector2[] velocityHistory;
        int activeValue;
        bool playerControl;
        Rectangle bounds;
        public Paddle(Texture2D image, Vector2 position, float radius, Color color, int precision, Rectangle bounds, bool playerControl) 
            : base(image, position, radius, color, 0)
        {
            this.precision = precision;
            this.bounds = bounds;
            this.playerControl = playerControl;
            lastPosition = position;
            velocityHistory = new Vector2[precision];
            activeValue = 0;
        }


        public void CenterAt(Vector2 newCenter)
        {
            Position = newCenter - new Vector2(Radius);
        }

        public void Update(GameTime gameTime)
        {
            if(playerControl)
            {
                CenterAt(InputManager.MousePosition);
            }
            keepWithinBounds(bounds);
            velocityHistory[activeValue++ % precision] = Position - lastPosition;
            Velocity = velocityHistory.Aggregate((sum, x) => sum + x) / precision;
            lastPosition = Position;
        }
    }
}
