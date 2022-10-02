namespace KalaMarket.EndPoint.Infrastructure.Settings
{
    public class IconSettings : object
    {
        public static readonly string KeyName = nameof(IconSettings);

        public IconSettings() : base()
        {
            UserIcons = new();

            TableIcons = new();

            SharedIcons = new();
        }

        public UserIcons UserIcons { get; set; }

        public TableIcons TableIcons { get; set; }

        public SharedIcons SharedIcons { get; set; }
    }
}
