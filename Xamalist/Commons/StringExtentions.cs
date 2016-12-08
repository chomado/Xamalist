using System;
namespace Xamalist.Commons
{
    public static class StringExtentions
    {
        public static bool IsNullOrEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }
    }
}
