using Microsoft.Data.SqlClient;

namespace SQL.init
{
    public class sql
    {
        private static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

        private static IConfigurationRoot configuration = builder.Build();

        private string strconn_init = configuration.GetConnectionString("InitConnection");
        private string strconn = configuration.GetConnectionString("DefaultConnection");
        public void init()
        {
            SqlConnection conexao = new SqlConnection(strconn_init);

            //CREATE DATABASE
            string sql = @"
                IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = N'dbsitesite')
                    BEGIN
                        CREATE DATABASE [dbsitesite];
                    END
            ";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conexao);

                conexao.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu algum erro");
                Console.WriteLine(@$"
                    sql: {sql} 
                    fail: {e.Message.ToString()}
                ");
            }
            finally
            {
                conexao.Close();
            }

            //INIT SQL
            conexao = new SqlConnection(strconn);

            try
            {
                using (var sr = new StreamReader("sql/init.sql"))
                {
                    sql = sr.ReadToEnd();

                    SqlCommand cmd = new SqlCommand(sql, conexao);

                    conexao.Open();
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu algum erro");
                Console.WriteLine(@$"
                    sql: {sql} 
                    fail: {e.Message.ToString()}
                ");
            }
            finally
            {
                conexao.Close();
            }
        }
    }

}