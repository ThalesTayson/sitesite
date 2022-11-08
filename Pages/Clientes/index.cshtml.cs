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
    public class index : PageModel
    {
        private readonly ILogger<index> _logger;

        public static cnx_BD db = new cnx_BD();
        public List<Cliente> clientes = db.listCliente();

        public index(ILogger<index> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}