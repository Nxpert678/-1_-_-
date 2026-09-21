using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_Scherbinin
{
    /// <summary>
    /// Общий контракт для всех численных методов решения f(x)=0.
    /// </summary>
    public interface IMethod
    {
        string Name { get; }
        MethodResult Solve(INonlinearEquation eq, double eps);
    }
}
