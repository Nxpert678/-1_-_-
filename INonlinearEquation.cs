using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_Scherbinin
{
    /// <summary>
    /// Описывает нелинейное уравнение f(x)=0, его производную
    /// и отображение для метода простой итерации.
    /// </summary>
    public interface INonlinearEquation
    {
        string Name { get; }
        double F(double x);       // f(x)
        double DF(double x);      // f'(x)
        double Phi(double x);     // phi(x) для простой итерации
        double DPhi(double x);    // phi'(x)
        double A { get; }         // левая граница отрезка
        double B { get; }         // правая граница
    }

}
