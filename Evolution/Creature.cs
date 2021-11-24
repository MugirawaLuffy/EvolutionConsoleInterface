using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Creature
    {
        public int xPos, yPos;
        public int killCount;
        public Brain brain;

        public Creature(int x, int y)
        {
            xPos = x;
            yPos = y;
            brain = new Brain();
        }
        public Creature(int x, int y, DNA d)
        {
            xPos = x;
            yPos = y;
            brain = new Brain();
            brain.dna = new DNA(d);
        }

        public void Tick()
        {
            brain.Tick(this);
        }

        public void MoveUp()
        {
            
            if (yPos > 0)
            {
                World.map[yPos, xPos] = false;
                if (World.map[yPos - 1, xPos] == true)
                    killCount++;
                World.map[yPos - 1, xPos] = true;
                yPos--;

            }
        }

        public void MoveDown()
        {
            if (yPos < World.wrldDimensions - 1)
            {
                World.map[yPos, xPos] = false;
                if (World.map[yPos + 1, xPos] == true)
                    killCount++;

                World.map[yPos + 1, xPos] = true;
                yPos++;
            }
            
        }

        public void MoveRight()
        {
            if(xPos < World.wrldDimensions - 1)
            {
                World.map[yPos, xPos] = false;

                if (World.map[yPos, xPos + 1] == true)
                    killCount++;
                World.map[yPos, xPos + 1] = true;
                xPos++;
            }
        }

        public void MoveLeft()
        {
            
            if(xPos > 0)
            {
                World.map[yPos, xPos] = false;
                if (World.map[yPos, xPos - 1] == true)
                    killCount++;
                World.map[yPos, xPos - 1] = true;
                xPos--;
            }

            
        }
    }
}
