using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Evolution
{
    public class EvolutionInterface
    {

        public EvolutionInterface()
        {
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
            foreach(Creature creature in creatures)
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


        public IEnumerable<Creature> Kill()
        {
            foreach (Creature creature in creatures)
            {
                if(creature.yPos < World.wrldDimensions/2)
                {
                    creature.brain = new Brain(); //generates entirely new DNA
                    
                }
                else
                {
                    Creature copy = creature;
                    creature.brain = new Brain(creature.brain.dna);
                    yield return copy;
                }
            }
        }
    }
}
