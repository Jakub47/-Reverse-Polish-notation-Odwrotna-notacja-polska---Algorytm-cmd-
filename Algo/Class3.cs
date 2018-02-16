using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stosik
{
    class Stack<T>
    {
        private T[] dane = new T[200];
        private int rozmiar { get; set; }

        public void Push(T c)
        {
            rozmiar = rozmiar + 1;
            dane[rozmiar] = c;
        }

        public T Pop()
        {
            T c = dane[rozmiar];
            if (rozmiar >= 1)
            {
                rozmiar = rozmiar - 1;
            }
            else
            {
                throw new Exception("stos pusty");
            }
            return c;
        }

        public int Count()
        {
            return rozmiar;
        }

        public T Peek()
        {
            return dane[rozmiar];
        }
    }
}
