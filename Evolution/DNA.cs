using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class DNA
    {
        static int dnaLength = 9; // 9 genes
        public List<Genome> genes;

        public DNA(int i)
        {

            genes = new List<Genome>();
        }

        public DNA()
        {

            DNA buf;
            CreateRandomStrand(out buf);
            genes = buf.genes;
        }
        public DNA(DNA toCopy)
        {
            genes = toCopy.genes;
            Mutate();
        }
        public DNA(DNA parent1, DNA parent2)
        {
            genes = new List<Genome>();
            Mutate();
        }

        public void Mutate()
        {
            
        }


        public static void CreateRandomStrand(out DNA dna) //LUMU10 LookUp-MoveUp Connection with weight 1.0 
        {
            dna = new DNA(1);

            int numNeurons = Enum.GetNames(typeof(NeuronOrder)).Length;
            string[] neurons = Enum.GetNames(typeof(NeuronOrder));

            for(int i = 0; i < dnaLength; i++)
            {
                string buffer = string.Empty;
                Random random = new Random();
                buffer += neurons[random.Next(0, numNeurons)];
                buffer += neurons[random.Next(0, numNeurons)];
                buffer += FloatToWeight((float)random.NextDouble());

                dna.genes.Add(new Genome(buffer));
                

            }

            
        }

        public static string FloatToWeight(float f) 
        {
            string buf = f.ToString("0.0");
            // float:   1.0
            // indeces: ^^^
            //          012
            return (buf[0].ToString() + buf[2].ToString()).ToString();
        }
        public static float WeightToFloat(string w)
        {
            if(w.Length > 1)
            {
                string output = w[0].ToString() + "." + w[1].ToString();
                
                return float.Parse(output, System.Globalization.CultureInfo.InvariantCulture); //1,3f
            }else
            {
                
                return float.Parse(w, System.Globalization.CultureInfo.InvariantCulture); //1,3f
            }
            
        }

        
        public override string ToString() 
        {
            string buffer = string.Empty;
            for (int i = 0; i < genes.Count; i++)
            {
                buffer += genes[i].Data;
                buffer += (i+1) % 3 == 0 ? "\n" : "  ";
            }

            return buffer;  
        }
    }
}
