using System;
using System.Configuration;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Transactions;

public class Service1 : IService1
{
    string connectionString = ConfigurationManager
        .ConnectionStrings["MyDbConnection"]
        .ConnectionString;

    [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
    public void TransferMoney(int fromId, int toId, int amount, bool simulateError)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd1 = new SqlCommand(
                    "UPDATE Accounts SET Balance = Balance - @amount WHERE Id = @id", conn);
                cmd1.Parameters.AddWithValue("@amount", amount);
                cmd1.Parameters.AddWithValue("@id", fromId);
                cmd1.ExecuteNonQuery();

                if (simulateError)
                {
                    throw new Exception("Simulated failure");
                }

                SqlCommand cmd2 = new SqlCommand(
                    "UPDATE Accounts SET Balance = Balance + @amount WHERE Id = @id", conn);
                cmd2.Parameters.AddWithValue("@amount", amount);
                cmd2.Parameters.AddWithValue("@id", toId);
                cmd2.ExecuteNonQuery();
            }

            scope.Complete();
        }
    }
}
