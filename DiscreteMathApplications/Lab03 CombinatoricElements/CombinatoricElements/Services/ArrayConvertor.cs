using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricElements.Services
{
    public class ArrayConvertor<T> : IArrayConvertor<T>
    {
        public T[] ConvertFromString(string str)
        {
            // tokenize
            var tokens = str.Split(',');
            var result = new List<T>();

            foreach(var token in tokens)
            {
                if(string.IsNullOrEmpty(token)) continue;

                // Convert the token to type T using Convert.ChangeType
                try
                {
                    var value = (T)Convert.ChangeType(token, typeof(T));
                    result.Add(value);
                }
                catch (Exception ex)
                {
                    // Handle any conversion exceptions as needed
                    // For example, log the exception or continue without adding the value
                    Console.WriteLine($"Failed to convert token '{token}' to type {typeof(T).Name}: {ex.Message}");
                }
            }

            return result.ToArray();
        }
    }
}
