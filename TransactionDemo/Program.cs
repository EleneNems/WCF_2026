using System;
using System.Transactions;
using TransactionDemo.BankServiceRef;

class Program
{
    static void Main(string[] args)
    {
        var client = new Service1Client();

        try
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Console.WriteLine("Starting transfer...");

                client.TransferMoney(1, 2, 100, true);

                scope.Complete();
            }

            Console.WriteLine("Transfer successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Transaction failed: " + ex.Message);
        }

        Console.ReadLine();
    }
}