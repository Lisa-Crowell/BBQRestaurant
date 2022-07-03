using BBQ.Services.Email.DbContexts;
using BBQ.Services.Email.Messages;
using BBQ.Services.Email.Models;
using Microsoft.EntityFrameworkCore;

namespace BBQ.Services.Email.Repository;

public class EmailRepository : IEmailRepository
{
    private readonly DbContextOptions<ApplicationDbContext> _dbContext;

    public EmailRepository(DbContextOptions<ApplicationDbContext> dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SendAndLogEmail(UpdatePaymentResultMessage message)
    {
       
        EmailLog emailLog = new EmailLog()
        {
            Email = message.Email,
            EmailSent = DateTime.Now,
            Log = $"Order - {message.OrderId} has been successfully created."
        };
        await using var _db = new ApplicationDbContext(_dbContext);
        _db.EmailLogs.Add(emailLog);
        await _db.SaveChangesAsync();
    }
}