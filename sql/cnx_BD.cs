using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SQL.DAO
{

    public class cnx_BD
    {
        #region Objetos Estáticos
        private static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

        private static IConfigurationRoot configuration = builder.Build();

        private string strconn = configuration.GetConnectionString("DefaultConnection");

        #endregion

        public string insert(string name_table, Dictionary<string, object> kwargs = null)
        {
            string str_field_sql = @$"INSERT INTO {name_table}(";
            string str_value_sql = @$"VALUES (";
            int cont = 0;
            foreach(var item in kwargs)
            {
                if (item.Value != null){
                    if (cont > 0){
                        str_field_sql += ", " + item.Key;
                        str_value_sql += @$", '{item.Value}'";
                    } else {
                        str_field_sql += item.Key;
                        str_value_sql += @$"'{item.Value}'";
                    }
                    cont += 1;                    
                }

            }
            string sql = @$"{str_field_sql}){"\r\n"}{str_value_sql});";
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();

                return  $"success";
            }
            catch (System.Exception e)
            {
                Console.WriteLine(@$"
                    sql: {sql} 
                    fail: {e.Message.ToString()}
                ");
                return "fail";
            }
            finally
            {
                conexao.Close();
            }

        }
        
        public Dictionary<string, Dictionary<string, string>> list(string name_table){
            SqlConnection conexao = new SqlConnection(strconn);
            string sql = $"SELECT * FROM {name_table}";
            SqlCommand cmd = new SqlCommand(sql, conexao);

            Dictionary<string, Dictionary<string, string>> list = new Dictionary<string, Dictionary<string, string>>();

            try
            {
                conexao.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (i > 0){
                            list[list.Last().Key].Add(reader.GetName(i), reader.GetValue(i).ToString());
                        } else {
                            list.Add(reader.GetValue(i).ToString(), new Dictionary<string, string>());
                        }
                    }
                }
                reader.Close();
                return list;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(@$"
                    sql: {sql}
                    fail: {e.Message.ToString()}
                ");
                return list;
            }
            finally
            {
                conexao.Close();
            }
        }
        public string delete(string name_table, int id)
        {
            SqlConnection conexao = new SqlConnection(strconn);
            string sql = $"DELETE FROM {name_table} WHERE id = {id};";
            SqlCommand cmd = new SqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return $"success";
            }
            catch (System.Exception e)
            {
                Console.WriteLine(@$"
                    sql: {sql} 
                    fail: {e.Message.ToString()}
                ");
                return "fail";
            }
            finally
            {
                conexao.Close();
            }
        }
        public string update(string name_table, int id, Dictionary<string, object> kwargs = null)
        {

            string sql = @$"UPDATE {name_table}{"\r\n"}SET ";

            int cont = 0;
            foreach(var item in kwargs)
            {
                if (item.Value != null){
                    if (cont > 0){
                        sql += @$",{"\r\n"}{item.Key} = '{item.Value}'";
                        
                    } else {
                        sql += @$"{item.Key} = '{item.Value}'";
                    }
                    cont += 1;
                }
            }

            sql += @$"{"\r\n"}WHERE id = {id};";

            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return  $"success";
            }
            catch (System.Exception e)
            {
                Console.WriteLine(@$"
                    sql: {sql} 
                    fail: {e.Message.ToString()}
                ");
                return "fail";
            }
            finally
            {
                conexao.Close();
            }
        }
        public Dictionary<string, string> get(int id, string name_table)
        {
            SqlConnection conexao = new SqlConnection(strconn);

            string sql = @$"
                SELECT * FROM {name_table}
                WHERE id = {id};
            ";

            SqlCommand cmd = new SqlCommand(sql, conexao); 
            try
            {
                conexao.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();
                
                Dictionary<string, string> dados = new Dictionary<string, string>();

                if (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dados.Add(reader.GetName(i), reader.GetValue(i).ToString());
                    }

                    return dados;
                } else
                {
                    reader.Close();
                    return null;
                }
                
            }
            catch (System.Exception e)
            {
                Console.WriteLine(@$"
                    sql: {sql} 
                    fail: {e.Message.ToString()}
                ");
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}