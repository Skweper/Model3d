using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Core
{
    public class Log
    {
        public Log(string path)
        {
            Path = path;
        }

        public void Write(string text)
        {
            StreamWriter writer = new StreamWriter(Path, true, Encoding.GetEncoding(1251));
            writer.WriteLine(DateTime.Now.ToShortTimeString() + "> " + text);
            writer.Close();
        }

        public void Clear()
        {
            StreamWriter writer = new StreamWriter(Path, false, Encoding.GetEncoding(1251));
            writer.Close();
        }

        public string Path { get; set; }
    }
}
