using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_zad
{
    public class Node : IComparable<Node>
    {
        public char Value { get; set; }
        public int Count { get; set; }

        public Node(char value, int count)
        {
            Value = value;
            Count = count;
        }
       
        public int CompareTo(Node other)
        {
            if(other == null)
                return 1;
            return Value.CompareTo(other.Value);
        }
    }
    public class OrderByFirstLetter
    {
        //posortowany set, łączy litery i freq w jeden element i zwraca posortowaną listę bez powtórzeń
        public ISet<Node> nodes = new SortedSet<Node>();
        public int[] Count { get; set; }
        public StringBuilder allFirstLetters = new();
        public OrderByFirstLetter(List<MyFile> myFiles)
        {           
            foreach (MyFile myFile in myFiles)
            {                
                char firstLett = myFile.Name.ToUpper()[0];
                allFirstLetters.Append(firstLett);                
            }
            Count = new int[allFirstLetters.Length];
            for (int i = 0; i < allFirstLetters.Length; i++)
            {
                Count[i] = allFirstLetters.ToString().Count(x => x == allFirstLetters[i]);
            }
            for (int i = 0; i < allFirstLetters.Length; i++)
            {
                nodes.Add(new Node(allFirstLetters[i], Count[i]));
            }

        }
        
        public void PrintByFirstLetter()
        {
            Console.WriteLine();
            Console.WriteLine("Counts by first letter:");
            foreach (Node node in nodes)
            {
                Console.WriteLine($"{node.Value} - {node.Count}");
            }
        }
        
    }
}
