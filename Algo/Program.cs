using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONP2;

namespace JNBGON
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cal: "); string odp = Console.ReadLine();
            zONP z = new zONP(odp);
            z.Przeksztalc();
        }
    }
}
