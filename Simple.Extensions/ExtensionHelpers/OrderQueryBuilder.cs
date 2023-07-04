using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Simple.Extensions.ExtensionHelpers
{
    internal static class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string orderByQueryString)
        {
            var orderParams = orderByQueryString.Trim().Split(',');

            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(' ')[0];

                var objectProperty = propertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") || param.EndsWith(" descending") || param.EndsWith(" d")
                    ? "descending"
                    : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                var firstProp = propertyInfos.FirstOrDefault();

                orderQuery = firstProp == default ? default : $"{firstProp.Name} ascending";
            }

            return orderQuery;
        }
    }
}
