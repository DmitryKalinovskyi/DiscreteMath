using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricElements.Services
{
    public class CombinatoricsService : ICombinatoricsService
    {
        // choose such prime modulo, that Modulo^2 < 10^18;
        public const long MODULO = 100_000_007;

        public long Combinations_nm(long n, long m)
        {
            // C(n, m) = n! / m! / (n - m)!

            return MultMod(Factorial(n), InverseFactorial(m), InverseFactorial(n - m));
        }

        public long Combinations_nm_Repeats(long n, long m)
        {
            // using stars and sticks method
            // you need to pack m stars inside n boxes
            // s|s|ss|
            // to do this, you place n - 1 in some way between m stars
            // then any this permutation will be one of the answers.

            // _
            // C(n, m) = (n + m - 1)! / (n - 1) / m! = C(n + m - 1, n - 1) = C(n + m - 1, m)

            return Combinations_nm(n + m - 1, m);
        }

        public long Permutations(long n)
        {
            return Factorial(n);
        }

        public long Permutations(long n, params long[] pieces)
        {
            // P(p1, p2, ..., pk) = n! / p1! / p2!, ..., /pk! =
            // = n! * (p1!)^(-1) * (p1!)^(-1) *, ..., (pn!)^(-1)

            var inverseFactorials = pieces.Select(InverseFactorial).ToArray();

            return MultMod(Factorial(n), MultMod(inverseFactorials));
        }

        public long Permutations_nm(long n, long m)
        {
            // A(n, m) = n! / (n - m)!;

            return MultMod(Factorial(n), InverseFactorial(n - m));
        }

        public long Permutations_nm_Repeats(long n, long m)
        {
            // _
            // A(n, m) = n^m;

            return BinaryExponentialByModulo(n, m);
        }


        #region Computational helping functions

        // a shoulb be < Modulo, in other case, program can be broked. :(
        private long BinaryExponentialByModulo(long a, long step)
        {
            if (step == 0) return 1;

            if (step % 2 == 0)
                return BinaryExponentialByModulo(a * a % MODULO, step / 2);

            return a * BinaryExponentialByModulo(a, step - 1) % MODULO;
        }

        // by small ferm theorem
        private long ModuloInverse(long a)
        {
            return BinaryExponentialByModulo(a, MODULO - 2);
        }

        private long Factorial(long a)
        {
            // if you know how to speed up that function please make pull request :)

            long b = 1;

            for(long i = 2; i <= a; i++)
            {
                b *= i;
                b %= MODULO;
            }

            return b;
        }

        private long InverseFactorial(long a)
        {
            return ModuloInverse(Factorial(a));
        }

        private long MultMod(params long[] a)
        {
            long b = a[0];

            for(int i = 1; i < a.Length; i++)
            {
                b *= a[i];
                b %= MODULO;
            }

            return b;
        }

        #endregion
    }
}
