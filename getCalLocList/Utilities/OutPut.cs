using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Utilities
{
    public class OutPut
    {
        private const string NORMAL_LOG = "OutputLog.txt";

        public static void Text(string text)
        {
            Console.WriteLine(text);
            using (var stream = new FileStream(NORMAL_LOG, FileMode.Append)) //IsolatedStorageFileStream(NORMAL_LOG, FileMode.Append, iso ))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss - "));
                    writer.WriteLine(text);
                    writer.Flush();
                }
            }
        }

        public static void Text(string text, params string[] details)
        {

            Console.WriteLine(text, details);
            using (var stream = new FileStream(NORMAL_LOG, FileMode.Append)) //IsolatedStorageFileStream(NORMAL_LOG, FileMode.Append))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss - "));
                    writer.WriteLine(text, details);
                    writer.Flush();
                }
            }
        }

        public static void Line()
        {
            var txt = "-".PadLeft(80);
            Text(txt);
        }
    }
}
