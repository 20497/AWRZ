using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AWRZ.DataBasePatterns;

using Dapper;

namespace AWRZ.App
{
    public class AppMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var connectionString = "Data Source=(LocalDB)'\'MSSQLLocalDb;Initial Catalog=awrz;Integrated Security=True";

            //TODO: use dapper, : SELECT * from FReelancers

            //https://dapper-tutorial.net/

            string sql = "SELECT * from Freelancer";

            using (var connection = new SqlConnection(connectionString))
            {
                var result = connection.Execute(sql, new { Freelancer = "Radek" });
                var affectedRows = connection.Execute(sql, new { Freelancer = "Radek" });

                Console.WriteLine(affectedRows);

                var freelancer = connection.Query<Freelancer>("Select * FROM Freelancer WHERE FirstName = 'Radek'").ToList();

                //FiddleHelper.WriteTable(freelancer); nie ma fiddle helpera w .net core, trzeba i tak w html wyświetlić - jak tam fantazja poniesie
            };

            Console.ReadKey();

        }
    }
}