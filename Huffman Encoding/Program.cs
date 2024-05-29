using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Huffman_Encoding
{
    class Program
    {
        static void Main(string[] args)
        {

            Sorted_list<int> list = new Sorted_list<int>();
            int max = 256;
            StreamReader reader = null;
            int value = -1;
            string input = "wap.txt";

            CharacterFrequency[] array;


            array = new CharacterFrequency[max];
            for (int i = 0; i < max; i++)
            {
                array[i] = new CharacterFrequency((char)i);
            }

            reader = new StreamReader(input);

            value = reader.Read();

            while (value != -1)
            {
                array[value].increment();
                value = reader.Read();
            }
            reader.Close();
            
            foreach (CharacterFrequency cf in array)
            {
                if (cf.freq >= 1)
                {
                  
                }

            }























        }


    }

   
}
