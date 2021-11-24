using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Evolution
{
    public class EvolutionInterface
    {
        public List<DNA> survivorDNA;
        

        public EvolutionInterface()
        {
            survivorDNA = new List<DNA>();
            //World.numCreatures = (int)Math.Round((World.wrldDimensions * World.wrldDimensions) * 0.75);
            //Console.WriteLine(World.numCreatures);
        }

        List<Creature> creatures = new List<Creature>();

        public void Setup()
        {
            for(int y = 0; y < World.wrldDimensions; y++)
            {
                for (int x = 0; x < World.wrldDimensions; x++)
                {
                    World.map[y, x] = false; //no space occupied
                }
            }
        }

        public bool PopulateArtficialLife()
        {
            for(int i = 0; i < World.numCreatures; i++)
            {
                int xPos = 0;
                int yPos = 0;

                Random rnd = new Random();
                bool isFree = false;
                //Console.WriteLine("!!!!");
                while(!isFree)
                {
                    xPos = rnd.Next(4, World.wrldDimensions - 5);
                    yPos = rnd.Next(4, World.wrldDimensions - 5);

                    if(World.map[yPos, xPos] == false)
                    {
                        isFree = true;
                        World.map[yPos, xPos] = true;
                    }
                }
                //Console.WriteLine("!!!!");
                creatures.Add(new Creature(xPos, yPos));
            }

            return true;
        }

        public void Simulate()
        {
            survivorDNA.Clear();
            foreach (Creature creature in creatures)
            {
                creature.Tick();
            }
        }
        public bool[,] Simulate(int i)
        {
            foreach (Creature creature in creatures)
            {
                creature.Tick();
            }

            return World.map;
        }


        public void Kill()
        {
            foreach (Creature creature in creatures)
            {
                if (!(creature.yPos < World.wrldDimensions / 2))
                {
                    survivorDNA.Add(creature.brain.dna);
                    
                }
            }
        }
        public void Repopulate()
        {
            int limitSurvivors = survivorDNA.Count;
            int limitNewComers = World.numCreatures - limitSurvivors;

            Setup();

            for (int i = 0; i < limitSurvivors; i++)
            {
                int xPos = 0;
                int yPos = 0;

                Random rnd = new Random();
                bool isFree = false;
                //Console.WriteLine("!!!!");
                while (!isFree)
                {
                    xPos = rnd.Next(4, World.wrldDimensions - 5);
                    yPos = rnd.Next(4, World.wrldDimensions - 5);

                    if (World.map[yPos, xPos] == false)
                    {
                        isFree = true;
                        World.map[yPos, xPos] = true;
                    }
                }
                //Console.WriteLine("!!!!");
                creatures.Add(new Creature(xPos, yPos,survivorDNA[i]));
            }

            for (int i = 0; i < limitNewComers; i++)
            {
                int xPos = 0;
                int yPos = 0;

                Random rnd = new Random();
                bool isFree = false;
                //Console.WriteLine("!!!!");
                while (!isFree)
                {
                    xPos = rnd.Next(4, World.wrldDimensions - 5);
                    yPos = rnd.Next(4, World.wrldDimensions - 5);

                    if (World.map[yPos, xPos] == false)
                    {
                        isFree = true;
                        World.map[yPos, xPos] = true;
                    }
                }
                //Console.WriteLine("!!!!");
                creatures.Add(new Creature(xPos, yPos));
            }

        }
    }
}
