using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_Scherbinin
{
    public class SimpleIterationMethod : IMethod
    {
        public string Name => "Простая итерация";

        private readonly double _x0;

        public SimpleIterationMethod(double x0) => _x0 = x0;

        public MethodResult Solve(INonlinearEquation eq, double eps)
        {
            PrintHeader();
            double x = _x0;
            int k = 0;
            double xn = x;

            while (true)
            {
                xn = eq.Phi(x);
                double dx = Math.Abs(xn - x);
                PrintRow(k, x, xn, dx, eq.F(xn));

                if (dx < eps) break;
                x = xn;
                k++;
            }

            return new MethodResult
            {
                MethodName = Name,
                Root = xn,
                Iterations = k,
                Residual = Math.Abs(eq.F(xn))
            };
        }

        private static void PrintHeader()
        {
            Console.WriteLine(new string('=', 70));
            Console.WriteLine("МЕТОД ПРОСТОЙ ИТЕРАЦИИ");
            Console.WriteLine(new string('=', 70));
            Console.WriteLine($"{"n",3} {"x_n",14} {"x_{n+1}",14} {"|dx|",14} {"f(x_{n+1})",14}");
        }

        private static void PrintRow(int k, double x, double xn, double dx, double f)
            => Console.WriteLine($"{k,3} {x,14:F6} {xn,14:F6} {dx,14:E3} {f,14:E3}");
    }
}
