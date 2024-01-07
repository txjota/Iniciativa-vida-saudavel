using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotsite.Models;

namespace Hotsite.Controllers
{
    public class HomeController : Controller
    {
       private readonly ILogger<HomeController> _logger;
    private readonly ILogger<DatabaseService> _dbLogger;

        public HomeController(ILogger<HomeController> logger, ILogger<DatabaseService> dbLogger)
    {
        _logger = logger;
        _dbLogger = dbLogger;
    }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
public IActionResult Cadastrar(Interesse cad)
{
    try
    {
        // Corrija esta linha, use _dbLogger que é do tipo ILogger<DatabaseService>
        DatabaseService dbs = new DatabaseService(_dbLogger);
        dbs.CadastraInteresse(cad);
        ViewBag.Message = "Cadastro realizado com sucesso!";
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erro ao cadastrar interesse");
        ViewBag.ErrorMessage = "Desculpe, não foi possível processar seu cadastro no momento. Tente novamente mais tarde.";
    }
    return View("Index", cad);
}

    }
}
