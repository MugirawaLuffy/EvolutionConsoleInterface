using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Genome
    {
        public string Data { get; private set; }

        public Genome()
        {
            Data = String.Empty;
        }
        public Genome(string strand)
        {
            Data = strand;
        }
    }
}
