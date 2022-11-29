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
    public class index : PageModel
    {
        private readonly ILogger<index> _logger;
        public ObjClientes clientes = new ObjClientes();

        public index(ILogger<index> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}