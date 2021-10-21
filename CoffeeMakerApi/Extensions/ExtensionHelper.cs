using System;

namespace CoffeeMakerApi.Extensions
{
    public static class ExtensionHelper
    {
        //Source: https://newbedev.com/how-to-truncate-milliseconds-off-of-a-net-datetime
        public static DateTimeOffset Truncate(this DateTimeOffset dateTime, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero) return dateTime;
            if (dateTime == DateTimeOffset.MinValue || dateTime == DateTimeOffset.MaxValue) return dateTime;
            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }
    }
}
