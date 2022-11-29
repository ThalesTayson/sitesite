using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using APP.Modelos;

namespace sitesite.Pages.Clientes
{
    public class delete : PageModel
    {
        private readonly ILogger<delete> _logger;

        public Cliente cliente = new Cliente();

        public delete(ILogger<delete> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            cliente.get(int.Parse(Request.Query["id"]));
        }
        public IActionResult OnPost()
        {
            cliente.get(int.Parse(Request.Form["id"]));
            cliente.delete();
            
            return Redirect("/Clientes");
        }
    }
}