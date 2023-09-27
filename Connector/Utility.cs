using Serilog;

namespace Connector
{
    public static class Utility
    {
        /// <summary>Converts to enum.</summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static TEnum ToEnum<TEnum>(this string? value, TEnum defaultValue) where TEnum : struct, IConvertible
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;
            TEnum resultInputType = default;
            bool enumParseResult = false;

            while (!enumParseResult)
            {
                enumParseResult = Enum.TryParse(value, true, out resultInputType);
            }
            return resultInputType;
        }

        /// <summary>Any the or not null.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static bool AnyOrNotNull<T>(this IEnumerable<T> source)
        {
            if (source != null && source.Any())
                return true;
            else
                return false;
        }

        public static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Logger.Error(messageTemplate: e.ExceptionObject.ToString());
        }
    }
}
