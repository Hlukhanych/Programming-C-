using System;
using System.Collections;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            List<string> key = new List<string> { "C", "D", "E", "F", "G", "A", "B" };
            List<string> value = new List<string> { "do", "re", "mi", "fa", "sol", "la", "si" };

            for (int i = 0; i < key.Count; i++)
            {
                ht.Add(key[i], value[i]);
            }

            foreach (string k in key)
            {
                Console.WriteLine($"{k}: {ht[k]}");
            }

            Console.WriteLine("reverse");

            key.Reverse();

            foreach (string k in key)
            {
                Console.WriteLine($"{k}: {ht[k]}");
            }

            Console.WriteLine(ht.Count);

            ht.Clear();
        }
    }
}