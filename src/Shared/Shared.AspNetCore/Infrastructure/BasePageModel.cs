using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.AspNetCore.Infrastructure.Messages;

namespace Shared.AspNetCore.Infrastructure;

/// <summary>
///     Version 3.0
/// </summary>
public abstract class BasePageModel :
    PageModel, IMessageHandler
{
    public bool AddPageError(string? message)
    {
        return AddMessage
            (MessageType.PageError, message);
    }

    public bool AddPageWarning(string? message)
    {
        return AddMessage
            (MessageType.PageWarning, message);
    }

    public bool AddPageSuccess(string? message)
    {
        return AddMessage
            (MessageType.PageSuccess, message);
    }

    public bool AddPageInformation(string? message)
    {
        return AddMessage(MessageType.PageInformation, message);
    }

    public bool AddToastError(string? message)
    {
        return AddMessage
            (MessageType.ToastError, message);
    }

    public bool AddToastWarning(string? message)
    {
        return AddMessage
            (MessageType.ToastWarning, message);
    }

    public bool AddToastSuccess(string? message)
    {
        return AddMessage
            (MessageType.ToastSuccess, message);
    }

    public bool AddToastInformation(string? message)
    {
        return AddMessage
            (MessageType.ToastInformation, message);
    }

    public bool AddMessage(MessageType type, string? message)
    {
        return Messages.Utility.AddMessage
            (TempData, type, message);
    }

    public bool AddRangeToastErrors(IList<string> messages)
    {
        foreach (var error in messages) AddToastError(error);
        return true;
    }

    public bool AddRangeToastSuccess(IList<string> messages)
    {
        foreach (var message in messages) AddToastSuccess(message);
        return true;
    }

    public bool AddRangeToastWarning(IList<string> messages)
    {
        foreach (var message in messages) AddToastWarning(message);
        return true;
    }

    public bool AddRangeToastInformation(IList<string> messages)
    {
        foreach (var message in messages) AddToastInformation(message);
        return true;
    }

    public bool AddRangePageErrors(IList<string> messages)
    {
        foreach (var message in messages) AddPageError(message);
        return true;
    }

    public bool AddRangePageSuccess(IList<string> messages)
    {
        foreach (var message in messages) AddPageSuccess(message);
        return true;
    }

    public bool AddRangePageInformation(IList<string> messages)
    {
        foreach (var message in messages) AddPageInformation(message);
        return true;
    }

    public bool AddRangePageWarning(IList<string> messages)
    {
        foreach (var message in messages) AddPageWarning(message);
        return true;
    }

    protected string SetReturnUrl(string? returnUrl)
    {
        if (string.IsNullOrWhiteSpace(returnUrl)) returnUrl = "./Index";

        return returnUrl;
    }
}