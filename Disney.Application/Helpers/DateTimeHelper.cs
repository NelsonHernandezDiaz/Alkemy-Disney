using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Helpers
{
    public static class DateTimeHelper
    {
        private const string TIMEZONE_USAGE = "Argentina Standard Time";

        public static DateTime GetSystemDate()
            => TimeZoneInfo.ConvertTimeFromUtc(
                DateTime.UtcNow,
                TimeZoneInfo.FindSystemTimeZoneById(TIMEZONE_USAGE)
                );
    }
}
