using KalaMarket.EndPoint.Infrastructure.Messages;

namespace KalaMarket.EndPoint.Infrastructure
{
	/// <summary>
	/// Version 3.0
	/// </summary>
	public abstract class BasePageModel :
		Microsoft.AspNetCore.Mvc.RazorPages.PageModel, Messages.IMessageHandler
	{
		public BasePageModel() : base()
		{
		}

		public bool AddPageError(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.PageError, message: message);
		}

		public bool AddPageWarning(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.PageWarning, message: message);
		}

		public bool AddPageSuccess(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.PageSuccess, message: message);
		}

        public bool AddPageInformation(string? message)
        {
            return AddMessage(type: Messages.MessageType.PageInformation, message: message);
        }

        public bool AddToastError(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.ToastError, message: message);
		}

		public bool AddToastWarning(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.ToastWarning, message: message);
		}

		public bool AddToastSuccess(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.ToastSuccess, message: message);
		}

        public bool AddToastInformation(string? message)
        {
            return AddMessage
                (type: Messages.MessageType.ToastInformation, message: message);
        }

        public bool AddMessage(Messages.MessageType type, string? message)
		{
			return Messages.Utility.AddMessage
				(tempData: TempData, type: type, message: message);
		}

		protected string SetReturnUrl(string? returnUrl)
		{
			if (string.IsNullOrWhiteSpace(value: returnUrl))
			{
				returnUrl = "./Index";
			}

			return returnUrl;
		}

        public bool AddRangeToastErrors(IList<string> messages)
        {
            foreach (var error in messages)
            {
                AddToastError(error);
            }
            return true;
        }

        public bool AddRangeToastSuccess(IList<string> messages)
        {
            foreach (var message in messages)
            {
                AddToastSuccess(message);
            }
            return true;
        }

        public bool AddRangeToastWarning(IList<string> messages)
        {
            foreach (var message in messages)
            {
                AddToastWarning(message);
            }
            return true;
        }

        public bool AddRangeToastInformation(IList<string> messages)
        {
            foreach (var message in messages)
            {
                AddToastInformation(message);
            }
            return true;
        }

        public bool AddRangePageErrors(IList<string> messages)
        {
            foreach (var message in messages)
            {
                AddPageError(message);
            }
            return true;
        }

        public bool AddRangePageSuccess(IList<string> messages)
        {
            foreach (var message in messages)
            {
                AddPageSuccess(message);
            }
            return true;
        }

        public bool AddRangePageInformation(IList<string> messages)
        {
            foreach (var message in messages)
            {
                AddPageInformation(message);
            }
            return true;
        }

        public bool AddRangePageWarning(IList<string> messages)
        {
            foreach (var message in messages)
            {
               AddPageWarning(message);
            }
            return true;
        }
    }
}
