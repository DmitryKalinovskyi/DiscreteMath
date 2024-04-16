using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricElements.Services
{
    public interface ICombinatoricsService
    {
        // make pull request if you have better naming ideas :)

        public long Permutations_nm(long n, long m);
        
        public long Permutations_nm_Repeats(long n, long m);

        public long Combinations_nm(long n, long m);
        
        public long Combinations_nm_Repeats(long n, long m);

        public long Permutations(long n);

        public long Permutations(long n, params long[] pieces);
    }
}
