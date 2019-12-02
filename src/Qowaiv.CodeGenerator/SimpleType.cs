using System;
using System.Collections.Generic;
using System.Linq;

namespace Qowaiv.CodeGenerator
{
    public static class SimpleType
    {
        public static string ToString(Type type)
        {
            if (type is null)
            {
                return string.Empty;
            }
            return aliases.TryGetValue(type, out var tp) ? tp : type.FullName;
        }

        public static Type Parse(string str)
        {
            var kvp = aliases.FirstOrDefault(k => k.Value.ToUpperInvariant() == str?.ToUpperInvariant());

            return kvp.Key is null
                ? Type.GetType(str)
                : kvp.Key;
        }

        private static readonly Dictionary<Type, string> aliases = new Dictionary<Type, string>
        {
            { typeof(byte), "byte" },
            { typeof(decimal), "decimal" },
            { typeof(double), "double" },
            { typeof(int), "int" },
            { typeof(string), "string" },
            { typeof(long), "long" },
            { typeof(short), "short" },
            { typeof(DateTime), "DateTime" },
            { typeof(Guid), "Guid" },
        };
    }
}
