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
        public List<int> ParseSetInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return new();

            List<int> result = new();
            foreach(var token in s.Split(','))
            {
                result.Add(int.Parse(token));
            }

            return result;
        }

        public List<double> ParseSetDouble(string s)
        {
            if (string.IsNullOrEmpty(s))
                return new();

            List<double> result = new();
            foreach (var token in s.Split(','))
            {
                result.Add(double.Parse(token));
            }

            return result;
        }

        public List<T> ParseSet<T>(string s) where T : IConvertible
        {
            if (string.IsNullOrEmpty(s))
                return new List<T>();

            List<T> result = new List<T>();
            foreach (var token in s.Split(','))
            {
                result.Add((T)Convert.ChangeType(token, typeof(T)));
            }

            return result;
        }

        public string SetToString<T>(List<T> set) 
        {
            return string.Join(", ", set);
        }
    }
}
