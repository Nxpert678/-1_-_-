using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_Scherbinin
{
    public class NewtonMethod : IMethod
    {
        public string Name => "Ньютон";

        private readonly double _x0;

        public NewtonMethod(double x0) => _x0 = x0;

        public MethodResult Solve(INonlinearEquation eq, double eps)
        {
            PrintHeader();
            double x = _x0;
            int k = 0;
            double xn = x;

            while (true)
            {
                xn = x - eq.F(x) / eq.DF(x);
                double dx = Math.Abs(xn - x);
                PrintRow(k, x, eq.F(x), eq.DF(x), xn, dx);

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
            Console.WriteLine("МЕТОД НЬЮТОНА");
            Console.WriteLine(new string('=', 70));
            Console.WriteLine($"{"k",3} {"x_k",14} {"f(x_k)",14} {"f'(x_k)",14} {"x_{k+1}",14} {"|dx|",14}");
        }

        private static void PrintRow(int k, double x, double fx, double dfx, double xn, double dx)
            => Console.WriteLine($"{k,3} {x,14:F6} {fx,14:E3} {dfx,14:F6} {xn,14:F6} {dx,14:E3}");
    }
}
