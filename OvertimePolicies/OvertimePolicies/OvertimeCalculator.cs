using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvertimePolicies
{
    public class OvertimeCalculator
    {
      public  decimal CalcurlatorA(decimal basicSalary,decimal allowance)
        {
          return 0.10m * (basicSalary + allowance);
        }
        public decimal CalcurlatorB(decimal basicSalary, decimal allowance)
        {
            return 0.20m * (basicSalary + allowance);
        }
        public decimal CalcurlatorC(decimal basicSalary, decimal allowance)
        {
            return 0.30m * (basicSalary + allowance);
        }
    }
}
