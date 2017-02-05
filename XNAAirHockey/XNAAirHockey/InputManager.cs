using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAAirHockey
{
    public static class InputManager
    {
        public static MouseState mouseState;
        public static Vector2 MousePosition => new Vector2(mouseState.X, mouseState.Y);
        public static KeyboardState keyboardState;
    }
}
