using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Streams
{
    class MemoryStreamReadWrite
    {
        private string _path;
        private string _text;

        UnicodeEncoding uniEncoding = new UnicodeEncoding();
        public MemoryStreamReadWrite(string path, string text)
        {
            _path = path;
            _text = text;
        }

        public void Write()
        {
            try
            {
                var textArray = uniEncoding.GetBytes(_text);

                using (var ms = new MemoryStream(textArray))
                {
                    using (var fs = new FileStream(_path, FileMode.Create, FileAccess.Write))
                    {
                        var bytes = new byte[ms.Length];

                        ms.Read(bytes, 0, (int)ms.Length);
                        fs.Write(bytes, 0, bytes.Length);

                        Console.WriteLine("Done write");
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Read()
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    using (var fs = new FileStream(_path, FileMode.Open, FileAccess.Read))
                    {
                        var bytes = new byte[fs.Length];

                        fs.Read(bytes, 0, (int)fs.Length);
                        ms.Write(bytes, 0, (int)fs.Length);

                        var charArray = new char[uniEncoding.GetCharCount(bytes, 0, bytes.Length)];
                        uniEncoding.GetDecoder().GetChars(bytes, 0, bytes.Length, charArray, 0);

                        Console.WriteLine(charArray);
                        Console.WriteLine("Done read");
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
