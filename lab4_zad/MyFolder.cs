using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_zad
{
    public class MyFolder
    {        
        public string? Path { get; set; }
        public long? Size { get; set; }

        public MyFolder(string? path, long size)
        {
            Path = path;
            Size = size;
        }

        public override string ToString()
        {
            return $"{Path} {Size}";
        }
    }
}
