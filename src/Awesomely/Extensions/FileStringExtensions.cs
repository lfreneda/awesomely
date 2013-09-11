using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Awesomely.Extensions
{
    public static class FileStringExtensions
    {
        public static void CreateIfNotExists(this string filePath)
        {
            if (File.Exists(filePath)) return;
            var f = File.Create(filePath);
            f.Close();
            f.Dispose();
        }

        public static StreamWriter ToStreamWriter(this string filePath, bool append, Encoding encoding)
        {
            return new StreamWriter(filePath, append, encoding);
        }

        public static StreamWriter ToStreamWriter(this string filePath, bool append)
        {
            return new StreamWriter(filePath, append);
        }

        public static StreamWriter ToStreamWriter(this string filePath)
        {
            return new StreamWriter(filePath);
        }

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
