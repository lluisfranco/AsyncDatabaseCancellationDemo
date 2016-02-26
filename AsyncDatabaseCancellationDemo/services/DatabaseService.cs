using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace AsyncDatabaseCancellationDemo.services
{
    class DatabaseService
    {
        const string _ConnectionString= "data source=.;initial catalog=AsyncDatabaseCancellationDemo;integrated security=True;MultipleActiveResultSets=True";
        public async static Task<decimal> GetCustomerCurrentAmount(int customerId, System.Threading.CancellationTokenSource sourceToken)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(_ConnectionString))
            {
                con.Open();
                var sql = string.Format("EXEC dbo.GetCustomerAmount {0}", customerId);
                var commandDefinition = new CommandDefinition(sql, new
                {
                    @CustomerId = customerId
                }, cancellationToken: sourceToken.Token);
                decimal amount = 0;
                try
                {
                    var data = await con.QueryAsync<decimal>(commandDefinition);
                    amount = data.FirstOrDefault();
                }
                catch (Exception)
                {
                    //throw;
                }
                con.Close();
                return amount;
            }               
        }

        public async static Task<List<dto.Customer>> GetCustomersList()
        {
            using (var con = new System.Data.SqlClient.SqlConnection(_ConnectionString))
            {
                con.Open();
                var sql = "SELECT * FROM dbo.Customers";
                var data = await con.QueryAsync<dto.Customer>(sql);
                con.Close();
                return data.ToList();
            }
        }
        
    }
}
