namespace Shared.AspNetCore.Infrastructure.Messages;

/// <summary>
///     Version 3.0
/// </summary>
public interface IMessageHandler
{
    bool AddPageError(string? message);

    bool AddPageWarning(string? message);

    bool AddPageSuccess(string? message);
    bool AddPageInformation(string? message);


    bool AddToastError(string? message);

    bool AddToastWarning(string? message);

    bool AddToastSuccess(string? message);
    bool AddToastInformation(string? message);


    bool AddMessage(MessageType type, string? message);
    public bool AddRangeToastErrors(IList<string> messages);
    public bool AddRangeToastSuccess(IList<string> messages);
    public bool AddRangeToastWarning(IList<string> messages);
    public bool AddRangeToastInformation(IList<string> messages);
    public bool AddRangePageErrors(IList<string> messages);
    public bool AddRangePageSuccess(IList<string> messages);
    public bool AddRangePageInformation(IList<string> messages);
    public bool AddRangePageWarning(IList<string> messages);
}