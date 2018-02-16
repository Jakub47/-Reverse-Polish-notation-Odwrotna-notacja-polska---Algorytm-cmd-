using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONP1;
using Stosik;

namespace ONP2
{
    public class zONP
    {
        public string[] value { get; set; }

        public zONP(string cal)
        {
            naOnp n = new naOnp();
            value = n.Stworz(cal).Split();
        }
        private float Swamp(float a, float b, char x)
        {
            float result = 0;
            if (x == '+') result = b + a;
            else if (x == '-') result = b - a;
            else if (x == '*') result = b * a;
            else if (x == '/') result = b / a;
            else if (x == '%') result = b % a;
            else if (x == '^') { result = b; while (a > 1) { result *= b; a--; } }
            return result;
        }
        public void Przeksztalc()
        {
            float wartosc = 0;
            Stack<float> stos = new Stack<float>();
            for (int i = 0; i < value.Length; i++)
            {

                string c = value[i].ToString();
                switch (c)
                {
                    case "+": wartosc = Swamp(stos.Pop(), stos.Pop(), '+'); stos.Push(wartosc); wartosc = 0; break;
                    case "-": wartosc = Swamp(stos.Pop(), stos.Pop(), '-'); stos.Push(wartosc); wartosc = 0; break;
                    case "*": wartosc = Swamp(stos.Pop(), stos.Pop(), '*'); stos.Push(wartosc); wartosc = 0; break;
                    case "/": wartosc = Swamp(stos.Pop(), stos.Pop(), '/'); stos.Push(wartosc); wartosc = 0; break;
                    case "%": wartosc = Swamp(stos.Pop(), stos.Pop(), '%'); stos.Push(wartosc); wartosc = 0; break;
                    case "^": wartosc = Swamp(stos.Pop(), stos.Pop(), '^'); stos.Push(wartosc); wartosc = 0; break;
                    case "": continue;
                    default: stos.Push(float.Parse(c)); break;

                    /* if (i == 0) stos.Push(float.Parse(c.ToString()));
                     else if (i > 0)
                     {
                         string q = stos.Peek().ToString();//q= 21   
                         if (q.Length > 1)
                         {
                             if (value[i - 1] == ' ') stos.Push(float.Parse(c.ToString()));
                             else if (value[i] == q[1]) { continue; }
                             else stos.Push(float.Parse(c.ToString()));
                         }
                         else
                             stos.Push(float.Parse(c.ToString()));*/
                }
            }
            Console.WriteLine(stos.Pop());
            Console.ReadKey();
        }
    }
}

