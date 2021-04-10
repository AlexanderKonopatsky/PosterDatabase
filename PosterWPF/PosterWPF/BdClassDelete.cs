using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PosterWPF
{
    class BdClassDelete
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AfishaEvent;Integrated Security=True";

        public void DeleteRowTable(int Id, string table)
        {
            try
            {
                string sqlExpression = "Delete" + table + "ById";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@deleteId", Id);

                    command.Parameters.Add(IdParameter);


                    var result = command.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
