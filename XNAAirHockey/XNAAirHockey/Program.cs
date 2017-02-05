using System;

namespace XNAAirHockey
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (XNAAirHockey game = new XNAAirHockey())
            {
                game.Run();
            }
        }
    }
#endif
}

