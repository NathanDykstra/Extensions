using System.Collections.Generic;
using System.Linq;

namespace Extensions.Collections
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Separates a collection into batches by the specified size or smaller if there are not enough elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="batchSize"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> BatchBy<T>(this IEnumerable<T> source, int batchSize)
        {
            var pos = 0;
            while (source.Skip(pos).Any())
            {
                yield return source.Skip(pos).Take(batchSize);
                pos += batchSize;
            }
        }
    }
}
