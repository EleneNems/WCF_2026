using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lecture4_Service
{
    [ServiceContract]

    public interface ICalculator
    {
        [OperationContract]
        int add(int a, int b);
    }
}
