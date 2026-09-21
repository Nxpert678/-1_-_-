using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_Scherbinin
{
    public class BisectionMethod : IMethod
    {
        public string Name => "Бисекция";

        public MethodResult Solve(INonlinearEquation eq, double eps)
        {
            double a = eq.A, b = eq.B;
            int k = 0;
            double c = 0;

            PrintHeader();
            while ((b - a) > eps)
            {
                c = (a + b) / 2.0;
                double fc = eq.F(c);
                PrintRow(k, a, b, c, fc);

                if (eq.F(a) * fc < 0) b = c;
                else a = c;
                k++;
            }
            c = (a + b) / 2.0;

            return new MethodResult
            {
                MethodName = Name,
                Root = c,
                Iterations = k,
                Residual = Math.Abs(eq.F(c))
            };
        }

        private static void PrintHeader()
        {
            Console.WriteLine(new string('=', 70));
            Console.WriteLine("МЕТОД БИСЕКЦИИ");
            Console.WriteLine(new string('=', 70));
            Console.WriteLine($"{"k",3} {"a",12} {"b",12} {"c",12} {"f(c)",14} {"b-a",12}");
        }

        private static void PrintRow(int k, double a, double b, double c, double fc)
            => Console.WriteLine($"{k,3} {a,12:F6} {b,12:F6} {c,12:F6} {fc,14:E3} {b - a,12:E3}");
    }
}
