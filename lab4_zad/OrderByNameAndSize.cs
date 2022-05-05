using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_zad
{
    public class OrderByNameAndSize : IEnumerable<ComposedKey>
    {
        //posortowany słownik z multi kluczem, można sortować na różne sposoby zależnie od potrzeby (bazwa pliku albo rozmiar)
        public IDictionary<ComposedKey, MyFile> dictionary = new SortedDictionary<ComposedKey, MyFile>();
        //public IDictionary<string, string> files = new SortedList<string, string>();
        public string? Name;
        public string? Size;
        
        
        public OrderByNameAndSize(List<MyFile> myFiles)
        {
            foreach (var item in myFiles)
            {
                Name = item.Name;
                Size = item.Size;
                
                ComposedKey composedKey = new(Name, Size);
                
                if (!dictionary.ContainsKey(composedKey))
                {
                    dictionary.Add(composedKey, item);                 
                }   
            }           
        }

        public IEnumerator<ComposedKey> GetEnumerator()
        {
            return dictionary.Keys.GetEnumerator();
        }             
       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PrintByName()
        {
            Console.WriteLine();
            Console.WriteLine("Order by name:");
            Console.WriteLine("\t \t[size] \t \t[path]");           
            foreach (KeyValuePair<ComposedKey, MyFile> item in dictionary)
            {                                
                Console.WriteLine(item.Key.KeyA + "\t" + item.Value.Size + "\t" + item.Value.Path);               
            }
        }

        public void PrintBySize()
        {
            Console.WriteLine();
            Console.WriteLine("Order by size:");
            Console.WriteLine("\t \t[size]");
            foreach (KeyValuePair<ComposedKey, MyFile> item in dictionary)
            {
                Console.WriteLine(item.Value.Name + "\t" + item.Key.KeyB);
            }
        }

        
    }

    public class ComposedKey : IComparable
    {
        public string? KeyA { get; }
        public string? KeyB { get; }
        

        public ComposedKey(string? keyA, string? keyB)
        {
            this.KeyA = keyA;
            this.KeyB = keyB;
            
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.KeyA, this.KeyB);
        }

        public override bool Equals(object? other)
        {
            return Equals(other as ComposedKey);
        }

        public bool Equals(ComposedKey? other)
        {
            return other != null
                && Equals(this.KeyA, other.KeyA)
                && Equals(this.KeyB, other.KeyB);
                
        }

        public override string ToString()
        {
            return $"({this.KeyA} {this.KeyB})";
        }

        public int CompareTo(object? obj)
        {
            int temp;
            if (obj == null)
                return 1;
            ComposedKey otherKey = obj as ComposedKey;
            return this.KeyA.CompareTo(otherKey.KeyA);
        }      
    }

    /*public class KeyComparer : IEqualityComparer<ComposedKey>
    {
        public bool Equals(ComposedKey? x, ComposedKey? y)
        {
            if (x == null)
                return y == null;

            if (y == null)
                return false;

            return String.Equals(x.KeyA, y.KeyA)
                && String.Equals(x.KeyB, y.KeyB)
                && String.Equals(x.KeyC, y.KeyC)
                && String.Equals(x.KeyD, y.KeyD);
        }

        public int GetHashCode([DisallowNull] ComposedKey key)
        {
            return HashCode.Combine(key.KeyA, key.KeyB, key.KeyC, key.KeyD);
        }
    }*/
    public class KeyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
    }



}
