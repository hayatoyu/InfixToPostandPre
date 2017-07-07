using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixtoPostandPre
{
    class Program
    {
        static void Main(string[] args)
        {
            string expr = "(a+b)*(c+d)";
            Infix infix = new Infix();
            Console.WriteLine(infix.toPostfix(expr));
            Console.WriteLine(infix.toPrefix(expr));
            Console.ReadLine();
        }
    }
}
