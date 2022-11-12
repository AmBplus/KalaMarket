namespace KalaMarket.Shared.DateTime;

public class PersianDateTime : PersianDate
{
    public PersianDateTime(System.DateTime dateTime) : base(dateTime)
    {
        Hour = dateTime.Hour;
        Minute = dateTime.Minute;
        Second = dateTime.Second;
    }

    public int Hour { get; }

    public int Minute { get; }

    public int Second { get; }

    public static string ConvertToDateTime(System.DateTime dateTime)
    {
        var persianDateTime =
            new PersianDateTime(dateTime);

        var result =
            persianDateTime.ToString();

        return result;
    }

    public override string ToString()
    {
        var hourString =
            Hour.ToString()
                .PadLeft(2, '0');

        var minuteString =
            Minute.ToString()
                .PadLeft(2, '0');

        var secondString =
            Second.ToString()
                .PadLeft(2, '0');

        var result =
            $"{base.ToString()} - {hourString}:{minuteString}:{secondString}";

        return result;
    }
}