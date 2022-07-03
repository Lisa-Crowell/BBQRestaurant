using BBQ.Services.Email.Messages;

namespace BBQ.Services.Email.Repository;

public interface IEmailRepository
{
    Task SendAndLogEmail(UpdatePaymentResultMessage message);
}