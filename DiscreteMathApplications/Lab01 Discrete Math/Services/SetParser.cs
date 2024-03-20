using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_Discrete_Math.Services
{
    public class SetParser
    {
        public HashSet<int> ParseSetInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return new();

            HashSet<int> result = new();
            foreach(var token in s.Split(','))
            {
                result.Add(int.Parse(token));
            }

            return result;
        }

        public HashSet<double> ParseSetDouble(string s)
        {
            if (string.IsNullOrEmpty(s))
                return new();

            HashSet<double> result = new();
            foreach (var token in s.Split(','))
            {
                result.Add(double.Parse(token));
            }

            return result;
        }

        public HashSet<T> ParseSetConcrete<T>(string s) where T : IConvertible
        {
            if (string.IsNullOrEmpty(s))
                return new HashSet<T>();

            HashSet<T> result = new();
            foreach (var token in s.Split(','))
            {
                result.Add((T)Convert.ChangeType(token, typeof(T)));
            }

            return result;
        }

        public HashSet<object> ParseSet(string s)
        {
            if (string.IsNullOrEmpty(s))
                return new();

            HashSet<object> result = new();
            foreach (var token in s.Split(','))
            {
                // clear token
                token.Trim();

                if (string.IsNullOrEmpty(token)) continue;

                // try by default convert to number, otherwise keep as string.

                if (long.TryParse(token, out long longValue))
                {
                    result.Add(longValue);
                }
                else if (double.TryParse(token, out double doubleValue))
                {
                    result.Add(doubleValue);
                }
                else
                {
                    result.Add(token); // Add as string
                }
            }

            return result;
        }

        public string SetToString<T>(HashSet<T> set) 
        {
            return string.Join(", ", set);
        }

        public string IEnumerableToString<T>(IEnumerable<T> enumerable)
        {
            return string.Join(", ", enumerable);
        }
    }
}
