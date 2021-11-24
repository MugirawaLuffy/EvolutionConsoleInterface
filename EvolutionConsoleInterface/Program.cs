using System;
using Evolution;
using System.Threading;
using System.Diagnostics;

public static class ConsoleInterface
{
    public static int Main(string[] args)
    {
        GraphicsLibrary.Graphics.Setup();
        EvolutionInterface eI = new EvolutionInterface(); //populate parameters

        int numTicks = 100;
        int gen = 0;
        
        eI.Setup();
        eI.PopulateArtficialLife();
        Stopwatch stopWatch = new Stopwatch();
        while (true)
        {
            Console.WriteLine("Start generation {0}? Type 'exit' to exit!", gen);
            if(Console.ReadLine().Equals("exit")) 
                break;

            Console.WriteLine("Simulating...");
            Console.WriteLine("...");
            stopWatch.Start();
            
            
            for (int i = 0; i < numTicks; i++)
            {
                if (i == 0 || i == World.wrldDimensions - 1)
                {
                    GraphicsLibrary.Graphics.PrintMap(eI.Simulate(i));
                }
                    
                eI.Simulate();
                
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Finished Simulation for generation {0} successfully", gen);
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            gen++;
        }

        
       
        return 0;      
    }
}
