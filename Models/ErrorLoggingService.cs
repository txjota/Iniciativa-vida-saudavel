using System;
using Hotsite.Models;


namespace Hotsite.Services
{
    public class ErrorLoggingService
    {
        private readonly DatabaseContext _context;
        
        public ErrorLoggingService(DatabaseContext context)
        {
            _context = context;
        }

       public void LogError(Exception ex)
{
    try
    {
        var errorLog = new ErrorLog
        {
            Message = ex.Message,
            StackTrace = ex.StackTrace,
            CreatedAt = DateTime.Now
        };

        _context.ErrorLogs.Add(errorLog);
        _context.SaveChanges();
    }
    catch (Exception logEx)
    {
        // Manejo de exceções do processo de log
        // Por exemplo, escrever em um arquivo de log local ou console
        Console.WriteLine("Erro ao registrar no log: " + logEx.Message);
    }
}

    }
}
