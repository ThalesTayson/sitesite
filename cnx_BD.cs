using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace sitesite.DAL
{

    public class cnx_BD
    {
        #region Objetos Estáticos
        private static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

        private static IConfigurationRoot configuration = builder.Build();

        private string strconn = configuration.GetConnectionString("DefaultConnection");

        #endregion

        public class objCliente
        {
            public int id;
            public string nome, email, fone, endereco ;

            public objCliente(int id, string nome, string email, string fone, string endereco)
            {
                this.id = id;
                this.nome = nome;
                this.email = email;
                this.fone = fone;
                this.endereco = endereco;
            }
        }
        public string insertCliente(string nome, string email, string fone, string endereco)
        {
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand(@$"
                INSERT INTO dbo.cliente (nome, email, fone, endereco)
                VALUES ('{nome}', '{email}', '{fone}', '{endereco}');
            ", conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return  $"Cadastro realizado com sucesso, { DateTime.Now }";
            }
            catch (System.Exception)
            {
                return $"Desculpa, Ocorreu um erro inesperado";
            }
            finally
            {
                conexao.Close();
            }
        }
        public List<objCliente> listCliente()
        {
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.cliente", conexao);

            List<objCliente> listaClientes = new List<objCliente>();

            try
            {
                conexao.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaClientes.Add(new objCliente(int.Parse(reader[0].ToString()), 
                        reader[1].ToString(), reader[2].ToString(), 
                        reader[3].ToString(), reader[4].ToString()
                    ));
                }
                reader.Close();
                return listaClientes;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Desculpa, Ocorreu um erro inesperado");
                return listaClientes;
            }
            finally
            {
                conexao.Close();
            }
        }
        public string deleteCliente(int id)
        {
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.cliente WHERE id = {id};", conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return "Cliente deletado com sucesso";
            }
            catch (System.Exception)
            {
                return "Desculpa, Ocorreu um erro inesperado";
            }
            finally
            {
                conexao.Close();
            }
        }
        public string editCliente(int id, string nome, string email, string fone, string endereco)
        {
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand(@$"
                UPDATE dbo.cliente
                SET nome = {nome}, email = {email}, fone = {fone}, endereco = {endereco}
                WHERE id = {id};
            ", conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return  $"Alterações de cadastro realizadas, { DateTime.Now }";
            }
            catch (System.Exception)
            {
                return "Desculpa, Ocorreu um erro inesperado";
            }
            finally
            {
                conexao.Close();
            }
        }
        public objCliente getCliente(int id)
        {
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand(@$"
                SELECT FROM dbo.cliente
                WHERE id = {id};
            ", conexao);
            try
            {
                conexao.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    objCliente cliente =  new objCliente(int.Parse(reader[0].ToString()), 
                        reader[1].ToString(), reader[2].ToString(), 
                        reader[3].ToString(), reader[4].ToString()
                    );
                    reader.Close();
                    return cliente;
                } else
                {
                    reader.Close();
                    return null;
                }
                
            }
            catch (System.Exception)
            {
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}