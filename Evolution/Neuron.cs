using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    internal abstract class Neuron
    {
        public abstract string Identifier { get; }

        public abstract float Fire(int x, int y, Creature c);
    }

    internal class EmptyNeuron : Neuron
    {
        public override string Identifier { get; } = "EN";
        public override float Fire(int x, int y, Creature c)
        {
            return 0.0f;
        }
    }

    internal class LookUpNeuron : Neuron
    {
        public override string Identifier { get; } = "LU";
        public override float Fire(int x, int y, Creature c)
        {
            //return 0.0 when space is free
            if(y>0)
            {
                if (World.map[y - 1, x] == false)
                    return 1f;
            }
                

            return 0f;
        }
    }

    internal class LookDownNeuron : Neuron
    {
        public override string Identifier { get; } = "LD";
        public override float Fire(int x, int y, Creature c)
        {
            //return 0.0 when space is free
            if (y < World.wrldDimensions - 1)
            {
                if (World.map[y + 1, x] == false)
                    return 1f;
            }
                

            return 0f;
        }
    }

    internal class LookRightNeuron : Neuron
    {
        public override string Identifier { get; } = "LR";
        public override float Fire(int x, int y, Creature c)
        {
            //return 0.0 when space is free
            if (x < World.wrldDimensions - 1)
            {
                if (World.map[y, x + 1] == false)
                    return 1f;
            }
                

            return 0f;
        }
    }

    internal class LookLeftNeuron : Neuron
    {
        public override string Identifier { get; } = "LL";
        public override float Fire(int x, int y, Creature c)
        {
            //return 0.0 when space is free
            if (x > 0)
            {
                if (World.map[y, x - 1] == false)
                    return 1f;
            }
                

            return 0f;
        }
    }

    internal class MoveUpNeuron : Neuron
    {
        public override string Identifier { get; } = "MU";

        public override float Fire(int x, int y, Creature c)
        {
            c.MoveUp();
            return 1.0f;
        }
    }
    internal class MoveDownNeuron : Neuron
    {
        public override string Identifier { get; } = "MD";

        public override float Fire(int x, int y, Creature c)
        {
            c.MoveDown();
            return 1.0f;
        }
    }
    internal class MoveLeftNeuron : Neuron
    {
        public override string Identifier { get; } = "ML";

        public override float Fire(int x, int y, Creature c)
        {
            c.MoveLeft();
            return 1.0f;
        }
    }
    internal class MoveRightNeuron : Neuron
    {
        public override string Identifier { get; } = "MR";

        public override float Fire(int x, int y, Creature c)
        {
            c.MoveRight();
            return 1.0f;
        }
    }



}
