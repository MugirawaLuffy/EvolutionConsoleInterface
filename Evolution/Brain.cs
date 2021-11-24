using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Brain
    {
        Neuron[] neurons = new Neuron[Enum.GetNames(typeof(NeuronOrder)).Length];
        public DNA dna;
        float threshhold = 0.5f;
        int step;


        public Brain()
        {
            int i = 0;
            foreach(string value in Enum.GetNames(typeof(NeuronOrder)))
            {
                neurons[i] = GetNeuron(value);
                i++;
            }
            dna = new DNA();
            step = 0;
        }
        public Brain(DNA _dna)
        {
            int i = 0;
            foreach (string value in Enum.GetNames(typeof(NeuronOrder)))
            {
                neurons[i] = GetNeuron(value);
                i++;
            }
            dna = _dna;
            step = 0;
        }

        private Neuron GetNeuron(string type)
        {
            switch(type)
            {
                case "LU":
                    {
                        return new LookUpNeuron();
                    }
                case "LD":
                    {
                        return new LookDownNeuron();
                    }
                case "LR":
                    {
                        return new LookRightNeuron();
                    }
                case "LL":
                    {
                        return new LookLeftNeuron();
                    }
                case "MU":
                    {
                        return new MoveUpNeuron();
                    }
                case "MD":
                    {
                        return new MoveDownNeuron();
                    }
                case "MR":
                    {
                        return new MoveRightNeuron();
                    }
                case "ML":
                    {
                        return new MoveLeftNeuron();
                    }
            }
            return new EmptyNeuron();

        }

        public void Tick(Creature c)
        {
            int[] indeces = new int[2];
            int steps = dna.genes.Count;
            int i = 0;
            string strand = dna.genes[step].Data;

            bool foundIndex = false;
            while(!foundIndex)
            {
                string comparer = strand.Substring(0, 2);
                if (neurons[i].Identifier == comparer)
                {
                    foundIndex = true;
                    indeces[0] = i;                    
                }
                i++;
            }

            i = 0;
            foundIndex = false;
            while (!foundIndex)
            {
                string comparer = strand.Substring(0, 2);
                if (neurons[i].Identifier == comparer)
                {
                    indeces[0] = i;
                    foundIndex = true;    
                }
                i++;
            }

            if (step < steps - 1)
                step++;
            else
                step = 0;

            FireConnection(c, neurons[indeces[0]], neurons[indeces[1]], DNA.WeightToFloat(strand.Substring(5)), c.xPos, c.yPos);
        }

        private void FireConnection(Creature c, Neuron startNeuron, Neuron endNeuron, float weight, int x, int y)
        {
            if(startNeuron.Fire(x, y, c) * (weight+0.5f) > threshhold)
            {
                endNeuron.Fire(x, y, c);
            }
        }

    }

    internal enum NeuronOrder
    {
        LU, LD, LR, LL,
        MU, MD, MR, ML,
    }
}
