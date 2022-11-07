using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using sitesite.DAL;

namespace sitesite.Pages.Clientes
{
    public class delete : PageModel
    {
        private readonly ILogger<delete> _logger;

        public static cnx_BD db = new cnx_BD();
        public string nomeCliente = "";
        public delete(ILogger<delete> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            nomeCliente = db.getCliente(int.Parse(Request.Query["id"])).nome;

        }
        public IActionResult OnPost()
        {
            db.deleteCliente(int.Parse(Request.Query["id"]));
            return Redirect("/Clientes");
        }
    }
}