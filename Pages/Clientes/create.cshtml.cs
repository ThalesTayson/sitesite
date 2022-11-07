using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace sitesite.Pages.Clientes
{
    public class create : PageModel
    {
        private readonly ILogger<create> _logger;

        public create(ILogger<create> logger)
        {
            _logger = logger;
        }

        public string Message { get; private set; } = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            string nome = Request.Form["name"];
            string email = Request.Form["email"];
            string fone = Request.Form["phone"];
            string endereco = Request.Form["adress"];

            string strcon = "Server=localhost\\SQLEXPRESS;Database=dbo.clientes;Trusted_Connection=True;TrustServerCertificate=True;Uid=dbaAdmin;Pwd=340$Uuxwp7Mcxo7Khy;";
            SqlConnection conexao = new SqlConnection(strcon);

            SqlCommand cmd = new SqlCommand(@$"
                INSERT INTO table_name (nome, email, fone, endereco)
                VALUES ({nome}, {email}, {fone}, {endereco});
            ", conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                Message = $"Cadastro realizado com sucesso, { DateTime.Now }";
            }
            catch (System.Exception)
            {
                Message = $"Desculpa, Ocorreu um erro inesperado";
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}