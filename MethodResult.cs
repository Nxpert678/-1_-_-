using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_Scherbinin
{
    /// <summary>
    /// Универсальный результат работы численного метода.
    /// </summary>
    public class MethodResult
    {
        public string MethodName { get; set; }
        public double Root { get; set; }
        public int Iterations { get; set; }
        public double Residual { get; set; }   // |f(root)|

        public override string ToString()
            => $"{MethodName,-22} | x = {Root:F6} | итераций: {Iterations,3} | невязка: {Residual:E3}";
    }
}
