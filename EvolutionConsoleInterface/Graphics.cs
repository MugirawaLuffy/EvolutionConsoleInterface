using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GraphicsLibrary
{
    public class Graphics
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);
        
        public static void Setup()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }

        public static void PrintMap(bool[,] map)
        {
            int living = 0;
            for(int i = 0; i < Evolution.World.wrldDimensions + 4; i++)
                Console.Write("_");
            Console.WriteLine();

            for (int y = 0; y < Evolution.World.wrldDimensions; y++)
            {
                Console.Write("| ");
                for (int x = 0; x < Evolution.World.wrldDimensions; x++)
                {
                    if(map[y,x])
                    {
                        Console.Write('O');
                        living++;
                    }else
                        Console.Write(' ');
                }
                //if(y == Evolution.World.wrldDimensions - 1)
                //    Console.Write("  |");
                //else
                Console.Write("  |\n"); 
            }
            
            for (int i = 0; i < Evolution.World.wrldDimensions + 4; i++)
                Console.Write("-");
            Console.WriteLine("Living: {0} creatures", living);
            Console.WriteLine();
        }
    }
}
