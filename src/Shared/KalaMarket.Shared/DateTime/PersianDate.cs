using System.Globalization;

namespace KalaMarket.Shared.DateTime;

public class PersianDate : object
{
    static PersianDate()
    {
        PersianCalendar =
            new PersianCalendar();
    }

    public PersianDate(System.DateTime dateTime)
    {
        DateTime = dateTime;

        Day =
            PersianCalendar.GetDayOfMonth(dateTime);

        Month =
            PersianCalendar.GetMonth(dateTime);

        Year =
            PersianCalendar.GetYear(dateTime);
    }

    protected static PersianCalendar PersianCalendar { get; }

    public int Day { get; }

    public int Month { get; }

    public int Year { get; }

    public System.DateTime DateTime { get; }

    public static string ConvertToDate(System.DateTime dateTime)
    {
        var persianDate =
            new PersianDate(dateTime);

        var result =
            persianDate.ToString();

        return result;
    }

    public override string ToString()
    {
        var dayString =
            Day.ToString()
                .PadLeft(2, '0');

        var monthString =
            Month.ToString()
                .PadLeft(2, '0');

        var result =
            $"{Year}/{monthString}/{dayString}";

        return result;
    }
}