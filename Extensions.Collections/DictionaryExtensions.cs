using System.Collections.Generic;

namespace Extensions.Collections
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adds or appends the collection to the dictionary at the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="dict">The dictionary to modify.</param>
        /// <param name="key">The key at which to add or append.</param>
        /// <param name="values">The collection of values to add or append.</param>
        public static void AddOrAppend<T, U>(this Dictionary<T, List<U>> dict, T key, IEnumerable<U> values)
        {
            if (dict.ContainsKey(key))
            {
                dict[key].AddRange(values);
            }
            else
            {
                dict[key] = new List<U>(values);
            }
        }
    }
}
