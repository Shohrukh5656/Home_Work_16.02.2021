using System;

namespace ConsoleApplication
{
    class Program
    {
        static Random random = new Random();
        static char AsciiCharacter
        {
            get
            {
                int t = random.Next(10);
                if (t <= 2)
                    return (char)('0' + random.Next(10));
                else if (t <= 4)
                    return (char)('i' + random.Next(27));
                else if (t <= 6)
                    return (char)('A' + random.Next(27));
                else
                    return (char)(random.Next(32, 255));
            }
        }
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();
            Console.CursorVisible = false;

            int Width, Height;
            int[] y;
            Initialize(out Width, out Height, out y);
            while (true)
                UpdateAllColumns(Width, Height, y);
        }


        private static void UpdateAllColumns(int Width, int Height, int[] y)
        {
            int x;
            for (x = 0; x < Width; ++x)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y[x]);
                Console.Write(AsciiCharacter);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp = y[x] - 2;
                Console.SetCursorPosition(x, inScreenYPosition(temp, Height));
                Console.Write(AsciiCharacter);
                int temp1 = y[x] - 20;
                Console.SetCursorPosition(x, inScreenYPosition(temp1, Height));
                Console.Write(' ');
                y[x] = inScreenYPosition(y[x] + 1, Height);
            }
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.F5)
                    Initialize(out Width, out Height, out y);
                if (Console.ReadKey().Key == ConsoleKey.F11)
                    System.Threading.Thread.Sleep(1);
            }

        }
        public static int inScreenYPosition(int yPosition, int Height)
        {
            if (yPosition < 0)
                return yPosition + Height;
            else if (yPosition < Height)
                return yPosition;
            else
                return 0;
        }
        private static void Initialize(out int Width, out int Height, out int[] y)
        {
            Height = Console.WindowHeight;
            Width = Console.WindowWidth - 1;
            y = new int[Width];

            Console.Clear();
            for (int x = 0; x < Width; ++x)
            {
                y[x] = random.Next(Height);
            }
        }
    }
}