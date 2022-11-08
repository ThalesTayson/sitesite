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
using sitesite.objetos;

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
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = Request.Form["name"];
            cliente.Email = Request.Form["email"];
            cliente.Fone = Request.Form["phone"];
            cliente.Endereco = Request.Form["adress"];
            
            string Message = db.insertCliente(cliente);
            Console.WriteLine(Message);
            return Redirect("/Clientes");
        }   
    }
}