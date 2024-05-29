using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Encoding
{
    public class CharacterFrequency
    {
        public char c;
       public int freq;
        public CharacterFrequency()
        {

        }
        public CharacterFrequency(char c)
        {
            this.c = c;

        }
        CharacterFrequency(char c, int f)
        {

            this.c = c;
            this.freq = f;
        }

        public int getC()
        {
            return c;
        }

        public void setC(char c)
        {
            this.c = c;
        }

        public int getFreq()
        {
            return freq;
        }

        public void setFreq(int freq)
        {
            this.freq = freq;
        }

        public void increment()
        {
            freq++;

        }

        public override string ToString()
        {
            return (char)c + "(" + (byte)c + ") \t" + freq;

        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj.GetType() == GetType()))
                return false;


            CharacterFrequency ch = (CharacterFrequency)obj;

            return this.c == ch.c;
        }
    }
}