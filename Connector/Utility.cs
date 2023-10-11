using Connector.Entities;
using Connector.Models;
using RestSharp;
using Serilog;
using System.Reflection;

namespace Connector
{
    /// <summary>Utility helper class</summary>
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
        public static bool AnyOrNotNull<T>(this IEnumerable<T> source) => source != null && source.Any();

        /// <summary>Unhandled the exception trapper.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs" /> instance containing the event data.</param>
        public static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Logger.Error(messageTemplate: e.ExceptionObject.ToString());

            //TODO: Logic for error handle.

        }

        /// <summary>Gets the name of the endpoint.</summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static string GetEndpointName(this string endpoint) => endpoint.Split('/').Last().ToString();

        /// <summary>Converts to key value.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static List<KeyValueParameter> ConvertToKeyValue<T>(ICollection<T> list) => (from row in list
                                                                                   select new KeyValueParameter
                                                                                   {
                                                                                       Key = GetValue<T>(row, "Key") ?? "",
                                                                                       Value = GetValue<T>(row, "Value") ?? "",
                                                                                   }).ToList();

        /// <summary>Gets the value.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static string? GetValue<T>(T obj, string name)
        {
            if (obj == null) return null;

            if (string.IsNullOrEmpty(name)) return null;

            var type = obj.GetType();

            var prop = type.GetProperty(name);

            if (prop == null) return null;

            var list = prop.GetValue(obj);

            return list?.ToString();
        }
    }
}
