using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using sitesite.DAL;
using sitesite.objetos;

namespace sitesite.Pages.Clientes
{
    public class delete : PageModel
    {
        private readonly ILogger<delete> _logger;

        public static cnx_BD db = new cnx_BD();
        public Cliente cliente = new Cliente();

        public delete(ILogger<delete> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            cliente = db.getCliente(int.Parse(Request.Query["id"]));
        }
        public IActionResult OnPost()
        {
            string Message = db.deleteCliente(int.Parse(Request.Form["id"]));
            Console.WriteLine(Message);
            return Redirect("/Clientes");
        }
    }
}