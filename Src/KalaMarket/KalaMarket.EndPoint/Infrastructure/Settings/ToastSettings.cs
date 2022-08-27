namespace KalaMarket.EndPoint.Infrastructure.Settings
{
	public class ToastSettings : object
	{
		public ToastSettings() : base()
		{
			DelayStep = 1000;
			InitialDelay = 5000;

			Style =
				"top-25 start-10 p-3 opacity-50";
		}
        public string ToasterError = nameof(ToasterError);
        public string ToasterWarning = nameof(ToasterWarning);
        public string ToasterSuccess = nameof(ToasterSuccess);
        public string ToasterInformation = nameof(ToasterInformation);
// **********
        public string Style { get; set; }
		// **********

		// **********
		public int DelayStep { get; set; }
		// **********

		// **********
		public int InitialDelay { get; set; }
		// **********
	}
}
