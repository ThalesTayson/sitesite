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
    public class edit : PageModel
    {
        private readonly ILogger<edit> _logger;
        
        public Cliente cliente = new Cliente();
        public edit(ILogger<edit> logger)
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
            cliente.Nome = Request.Form["name"];
            cliente.Email = Request.Form["email"];
            cliente.Fone = Request.Form["phone"];
            cliente.Endereco = Request.Form["adress"];

            cliente.save();
            
            return Redirect("/Clientes");
        }
    }
}