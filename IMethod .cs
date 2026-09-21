using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_Scherbinin
{
    /// <summary>
    /// Уравнение варианта 11: f(x) = e^(-x) - x.
    /// Отображение для простой итерации: phi(x) = e^(-x).
    /// </summary>
    public class ExpMinusXEquation : INonlinearEquation
    {
        public string Name => "e^(-x) - x = 0";
        public double A => 0.0;
        public double B => 1.0;

        public double F(double x) => Math.Exp(-x) - x;
        public double DF(double x) => -Math.Exp(-x) - 1;
        public double Phi(double x) => Math.Exp(-x);
        public double DPhi(double x) => -Math.Exp(-x);
    }
}
