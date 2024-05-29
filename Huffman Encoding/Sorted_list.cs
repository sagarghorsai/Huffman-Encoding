using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Encoding
{
    class Sorted_list<T> : LinkedList<T> where T : IComparable
    {
        private readonly LinkedList<T> _list;

        
        public Sorted_list()
        {
            _list = new LinkedList<T>();
        }
        public LinkedList<T>.Enumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        public void Add(T element)
        {
            if (_list.Count() == 0)
            {
                _list.AddFirst(element);
            }

            else if (element.CompareTo(_list.Last.Value) < 0)
            {
                _list.AddLast(element);


            }
            else if (element.CompareTo(_list.First.Value) > 0)
            {
                _list.AddFirst(element);
            }



            else
            {
                var i = _list.First;

                while (i != null)
                {
                    if(element.CompareTo(i.Value) > 0|| element.Equals(i.Value))
                     {
                        _list.AddBefore(i, element);
                        i = _list.Last;
                    }


                        i = i.Next;
                }

              

            }
        }
      

    }
}


