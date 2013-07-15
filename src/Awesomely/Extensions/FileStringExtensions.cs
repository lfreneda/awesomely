using System.IO;
using System.Collections.Generic;

namespace awesomely.Extensions
{
    public static class FileStringExtensions
    {
        public static void AppendToFile(this string str, string filePath)
        {
            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(str);
            }
        }

        public static void Append(this string filePath, string str)
        {
            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(str);
            }
        }

        public static IEnumerable<string> CreateEnumerable(this string filePath)
        {
            var file = new StreamReader(filePath);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                yield return line.Trim();
            }
            file.Close();
            file.Dispose();
        }
    }
}
