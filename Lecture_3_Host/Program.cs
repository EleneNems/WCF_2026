using System;
using System.ServiceModel;

namespace Lecture_3_Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Lecture_3_Service.CalculatorService)))
            {
                host.Open();
                Console.WriteLine("Press Enter to stop.");
                Console.ReadLine();
            }
        }
    }
}