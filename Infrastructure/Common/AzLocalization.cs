using System;
using System.Globalization;

namespace Infrastructure.Common
{
    public static class AzLocalization
    {
        public static bool Apply = true;
        public static DateTime ToAzDateTime(this DateTime dateTime)
        {
            if (!Apply) return dateTime;


            string zoneId = "Azerbaijan Standard Time";
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
            DateTime result = TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), tzi);
            return result;

        }


        public static string ToAzDateTimeFormatFull(this DateTime dateTime)
        {
            var cultInfo = CultureInfo.GetCultureInfo("az-Latn-AZ");
            var azDateTime = ToAzDateTime(dateTime);

            return azDateTime.ToString("f", cultInfo);

        }

        public static string ToAzDateTimeFormatShort(this DateTime dateTime)
        {
            var cultInfo = CultureInfo.GetCultureInfo("az-Latn-AZ");
            var azDateTime = ToAzDateTime(dateTime);

            return azDateTime.ToString("dd-MMMM-yyyy", cultInfo);

        }


        public static TimeSpan Difference(this DateTime left, DateTime right)
        {
            return left - right;
        }


        public static string AzCurrency(this decimal value)
        {
            var cultInfo = CultureInfo.GetCultureInfo("az-Latn-AZ");
            return value.ToString("C", cultInfo);
        }
    }
}
