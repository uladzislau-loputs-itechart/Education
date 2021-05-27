using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Streams
{
    class FileStreamReadWrite
    {
        private string _path;
        private string _text;
        public FileStreamReadWrite(string path, string text)
        {
            _path = path;
            _text = text;
        }

        public void Write()
        {
            try
            {
                using (FileStream fs = File.Create(_path))
                {
                    using (var sr = new StreamWriter(fs))
                    {
                        sr.WriteLine(_text);
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
                using (FileStream fs = File.OpenRead(_path))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
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
