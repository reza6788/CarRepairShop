using CarRepairShop.Application.Services.Email;
using CarRepairShop.Domain.Events.Customer;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CarRepairShop.Application.EventHandlers.Customer;

public class CreateCustomerEventHandler : INotificationHandler<CreateCustomerEvent>
{
    private readonly IEmailService _emailService;
    private bool SendNotificationCustomer { get; }
    private string NotificationCustomerTo { get; }

    public CreateCustomerEventHandler(IEmailService emailService, IConfiguration configuration)
    {
        _emailService = emailService;
        SendNotificationCustomer = bool.Parse(configuration["Send_Notification_Customer"] ?? "false");
        NotificationCustomerTo = configuration["Notification_Customer_To"] ?? "";
    }

    public Task Handle(CreateCustomerEvent notification, CancellationToken cancellationToken)
    {
        if (!SendNotificationCustomer) return Task.CompletedTask;
        var body= GetCustomerCreatedEmailBody(notification.CustomerId,notification.FullName,notification.OccurredOn);

        _emailService.SendEmailAsync(NotificationCustomerTo, "Customer notification", body);

        return Task.CompletedTask;
    }
    
    public static string GetCustomerCreatedEmailBody(Guid customerId, string fullName, DateTime occurredOn)
    {
        return $@"
        <html>
        <body>
            <h2>New Customer Created</h2>
            <p>A new customer has been successfully created in the system.</p>
            <table border='1' cellpadding='5' cellspacing='0'>
                <tr>
                    <th>Customer ID</th>
                    <td>{customerId}</td>
                </tr>
                <tr>
                    <th>Full Name</th>
                    <td>{fullName}</td>
                </tr>
                <tr>
                    <th>Created On</th>
                    <td>{occurredOn:yyyy-MM-dd HH:mm:ss}</td>
                </tr>
            </table>
            <p>Please take any necessary follow-up actions.</p>
        </body>
        </html>
    ";
    }
}