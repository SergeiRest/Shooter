using System;

namespace Main
{
    public static class Extensions
    {
        public static TimeSpan ToSec(this float time)
        {
            return TimeSpan.FromSeconds(time);
        }
    }
}