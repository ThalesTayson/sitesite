using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using sitesite.objetos;
namespace sitesite.Pages.Clientes
{
    public class edit : PageModel
    {
        private readonly ILogger<edit> _logger;

        public static cnx_BD db = new cnx_BD();
        
        public Cliente cliente = new Cliente();
        public edit(ILogger<edit> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            cliente = db.getCliente(int.Parse(Request.Query["id"]));
        }
        public IActionResult OnPost()
        {
            Cliente cliente = new Cliente();
            cliente.Id = int.Parse(Request.Form["id"]);
            cliente.Nome = Request.Form["name"];
            cliente.Email = Request.Form["email"];
            cliente.Fone = Request.Form["phone"];
            cliente.Endereco = Request.Form["adress"];
            string Message = db.editCliente(cliente);
            Console.WriteLine(Message);
            return Redirect("/Clientes");
        }
    }
}