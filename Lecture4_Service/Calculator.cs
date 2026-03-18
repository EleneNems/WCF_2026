using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lecture4_Service
{
    [ServiceContract]
    public class Calculator : ICalculator
    {
        [OperationContract]
        public int add(int a, int b)
        {
            return a + b;
        }
    }
}
