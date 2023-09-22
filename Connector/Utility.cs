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
    }
}
