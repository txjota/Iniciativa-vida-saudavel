using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hotsite.Models
{
    public class DatabaseService
    {
        private readonly ILogger<DatabaseService> _logger;

        public DatabaseService(ILogger<DatabaseService> logger)
        {
            _logger = logger;
        }

        public int CadastraInteresse(Interesse cad)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.Add(cad);
                    context.SaveChanges();
                    return cad.Id;
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Erro ao atualizar o banco de dados ao cadastrar interesse.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar interesse.");
                throw;
            }
        }
    }
}
