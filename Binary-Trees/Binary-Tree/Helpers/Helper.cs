using System.Collections;

namespace Binary_Tree.Helpers
{
    public static class Helper
    {
        public static void Print<T>(this IEnumerable<T> collection, bool singleLine = true)
        {
            const char whitespace = ' ';
            const char newLine = '\n';

            var separator = singleLine ? whitespace : newLine;
            Console.WriteLine(string.Join(separator, collection));
        }
    }
}
