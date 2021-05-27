using System;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"D:\git\Education\Nickerm\Streams\text.txt";
            string path2 = @"D:\git\Education\Nickerm\Streams\text2.txt";
            string text = "Some text23";
            string text2 = "Some text23222";
            //var fs = new FileStreamReadWrite(path1, text);
            //fs.Write();
            //fs.Read();
            var ms = new MemoryStreamReadWrite(path2, text2);
            ms.Write();
            ms.Read();
        }
    }
}
