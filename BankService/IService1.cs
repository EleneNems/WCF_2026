using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


[ServiceContract]
public interface IService1
{
    [OperationContract]
    void TransferMoney(int fromId, int toId, int amount, bool simulateError);
}
