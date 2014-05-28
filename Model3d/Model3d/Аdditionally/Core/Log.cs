using System;
using System.IO;
using System.Text;

namespace Additionally.Core
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
            writer.Write(text);
            writer.Close();
        }

        public void WriteLine(string text)
        {
            StreamWriter writer = new StreamWriter(Path, true, Encoding.GetEncoding(1251));
            writer.WriteLine(text);
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
