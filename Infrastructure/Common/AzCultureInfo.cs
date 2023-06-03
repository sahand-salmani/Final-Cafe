using System;
using System.Globalization;

namespace Infrastructure.Common
{
    public class AzCultureInfo
    {
        public CultureInfo AzCulture()
        {
            return CultureInfo.GetCultureInfo("az-Latn-AZ");
        }


        public string ToAzDateTimeFormatFull(DateTime dateTime)
        {
            var cultInfo = AzCulture();
            var azDateTime = dateTime.ToAzDateTime();

            return azDateTime.ToString("D", cultInfo);

        }

        public string ToAzDateTimeFormatShort(DateTime dateTime)
        {
            var cultInfo = AzCulture();
            var azDateTime = dateTime.ToAzDateTime();
            return azDateTime.ToString("dd-MMM-yyyy", cultInfo);
        }

        public DateTime ToAzTime(DateTime dateTime)
        {
            return dateTime.ToAzDateTime();
        }


        public TimeSpan Difference(DateTime left, DateTime right)
        {
            return left.Difference(right);
        }


        public string AzCurrency(decimal value)
        {
            return value.AzCurrency();
        }



    }
}
