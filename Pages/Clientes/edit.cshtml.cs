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
    public class edit : PageModel
    {
        private readonly ILogger<edit> _logger;

        public static cnx_BD db = new cnx_BD();
        
        public edit(ILogger<edit> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            cnx_BD.objCliente cliente = db.getCliente(int.Parse(Request.Query["id"]));
        }
    }
}