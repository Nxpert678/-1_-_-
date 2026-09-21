using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_Scherbinin
{
    internal class Program
    {
        private const double EPS = 1e-4;

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Создаём уравнение
            INonlinearEquation eq = new ExpMinusXEquation();

            Console.WriteLine($"\nУравнение: {eq.Name}");
            Console.WriteLine($"Отрезок: [{eq.A}; {eq.B}], точность eps = {EPS:E0}\n");

            PrintSeparation(eq);

            // Собираем методы в список
            var methods = new List<IMethod>
            {
                new BisectionMethod(),
                new SimpleIterationMethod(x0: 0.5),
                new NewtonMethod(x0: 0.0),     // по правилу Фурье
                new SecantMethod(x0: eq.A, x1: eq.B)
            };

            // Запускаем и собираем результаты
            var results = new List<MethodResult>();
            foreach (var method in methods)
            {
                var result = method.Solve(eq, EPS);
                results.Add(result);
                Console.WriteLine($"\nКорень: x = {result.Root:F6}, " +
                                  $"итераций: {result.Iterations}, " +
                                  $"невязка = {result.Residual:E3}\n");
            }

            PrintComparison(results);
            Console.WriteLine("\nТочное значение: x* = W(1) ≈ 0.5671432904");
            Console.ReadKey();
        }

        private static void PrintSeparation(INonlinearEquation eq)
        {
            Console.WriteLine(new string('=', 70));
            Console.WriteLine("ОТДЕЛЕНИЕ КОРНЕЙ");
            Console.WriteLine(new string('=', 70));
            Console.WriteLine($"f({eq.A}) = {eq.F(eq.A):F6}");
            Console.WriteLine($"f({eq.B}) = {eq.F(eq.B):F6}");
            Console.WriteLine("Знак меняется ⇒ корень на отрезке.");

            Console.WriteLine("\nПроверка сходимости простой итерации:");
            Console.WriteLine($"|phi'({eq.A})| = {Math.Abs(eq.DPhi(eq.A)):F6}");
            Console.WriteLine($"|phi'(x*≈0.567)| = {Math.Abs(eq.DPhi(0.567)):F6} < 1 ✔\n");
        }

        private static void PrintComparison(List<MethodResult> results)
        {
            Console.WriteLine(new string('=', 70));
            Console.WriteLine("СРАВНЕНИЕ МЕТОДОВ");
            Console.WriteLine(new string('=', 70));
            Console.WriteLine($"{"Метод",-22} {"Корень",12} {"Итераций",10} {"Невязка",12}");
            Console.WriteLine(new string('-', 70));

            foreach (var r in results)
            {
                Console.WriteLine($"{r.MethodName,-22} {r.Root,12:F6} {r.Iterations,10} {r.Residual,12:E3}");
            }
            Console.WriteLine(new string('=', 70));
        }
    }
}
