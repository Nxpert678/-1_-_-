using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_Scherbinin
{
    public class SecantMethod : IMethod
    {
        public string Name => "Секущие";

        private readonly double _x0;
        private readonly double _x1;

        public SecantMethod(double x0, double x1)
        {
            _x0 = x0;
            _x1 = x1;
        }

        public MethodResult Solve(INonlinearEquation eq, double eps)
        {
            PrintHeader();
            double xPrev = _x0;
            double x = _x1;
            int k = 0;
            double xn = x;

            while (true)
            {
                double fPrev = eq.F(xPrev);
                double fCur = eq.F(x);

                if (Math.Abs(fCur - fPrev) < 1e-15)
                {
                    Console.WriteLine("Деление на ноль — метод остановлен.");
                    break;
                }

                xn = x - fCur * (x - xPrev) / (fCur - fPrev);
                double dx = Math.Abs(xn - x);
                PrintRow(k, xPrev, x, fCur, xn, dx);

                if (dx < eps) break;
                xPrev = x;
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
            Console.WriteLine("МЕТОД СЕКУЩИХ");
            Console.WriteLine(new string('=', 70));
            Console.WriteLine($"{"k",3} {"x_{k-1}",14} {"x_k",14} {"f(x_k)",14} {"x_{k+1}",14} {"|dx|",14}");
        }

        private static void PrintRow(int k, double xPrev, double x, double fCur, double xn, double dx)
            => Console.WriteLine($"{k,3} {xPrev,14:F6} {x,14:F6} {fCur,14:E3} {xn,14:F6} {dx,14:E3}");
    }
}
