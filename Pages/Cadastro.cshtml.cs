using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace sitesite.Pages;

public class CadastroModel : PageModel
{
    private readonly ILogger<CadastroModel> _logger;

    public CadastroModel(ILogger<CadastroModel> logger)
    {
        _logger = logger;
    }
    public string Message { get; private set; } = "";

    public void OnGet()
    {
        Console.WriteLine("Metodo Get");
    }   
    

    public void OnPost()
    {
        Console.WriteLine(Request.Form["nome"]);
        Message = $"Cadastro realizado com sucesso, { DateTime.Now }";
        ;
    }
}