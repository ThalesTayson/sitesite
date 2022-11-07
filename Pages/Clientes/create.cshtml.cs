using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using sitesite.DAL;

namespace sitesite.Pages.Clientes
{   
    
    public class create : PageModel
    {
        private readonly ILogger<create> _logger;

    
        public create(ILogger<create> logger)
        {
            _logger = logger;
        }
        
        public static cnx_BD db = new cnx_BD(); 

        public string Message { get; private set; } = "";
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            string nome = Request.Form["name"];
            string email = Request.Form["email"];
            string fone = Request.Form["phone"];
            string endereco = Request.Form["adress"];
            
            db.insertCliente(nome, email, fone, endereco);

            return Redirect("/Clientes");
        }   
    }
}