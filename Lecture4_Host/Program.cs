using Lecture4_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lecture4_Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Lecture4_Service.Calculator)))
            {
                host.Open();
                Console.WriteLine("Press Enter to stop.");
                Console.ReadLine();
            }
        }
    }
}
