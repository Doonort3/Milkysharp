#region

using COSMOS_RTC = Cosmos.HAL.RTC;

#endregion

namespace Milkysharp.Other;

public static class Rtc
{
    // time
    public static int GetHour()
    {
        return COSMOS_RTC.Hour;
    }

    public static int GetMinute()
    {
        return COSMOS_RTC.Minute;
    }

    public static int GetSecond()
    {
        return COSMOS_RTC.Second;
    }

    // time - strings
    public static string GetTime()
    {
        return COSMOS_RTC.Hour + ":" + COSMOS_RTC.Minute + ":" + COSMOS_RTC.Second;
    }

    // formatted date
    public static string GetDateFormatted()
    {
        var date = "00/00/0000";
        date = COSMOS_RTC.Month + "/" + COSMOS_RTC.DayOfTheMonth + "/20" + COSMOS_RTC.Year;
        return date;
    }

    // formatted time
    public static string GetTimeFormatted()
    {
        string hour, minute;

        // format hour
        int hr;
        var morning = true;
        if (GetHour() <= 12)
        {
            hr = GetHour();
            if (hr < 11) morning = true;
        }
        else
        {
            hr = GetHour() - 12;
            if (hr < 12) morning = false;
        }

        // format hour
        if (hr < 10) hour = "0" + hr;
        if (hr == 0)
            hour = "12";
        else
            hour = hr.ToString();

        // format minute
        if (COSMOS_RTC.Minute < 10)
            minute = "0" + COSMOS_RTC.Minute;
        else
            minute = COSMOS_RTC.Minute.ToString();

        // am or pm?
        if (morning)
            return hour + ":" + minute + " AM";
        return hour + ":" + minute + " PM";
    }
}