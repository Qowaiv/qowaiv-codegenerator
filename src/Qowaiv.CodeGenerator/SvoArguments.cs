using System;
using System.Collections.Generic;

namespace Qowaiv.CodeGenerator
{
    public class SvoArguments
    {
        public SvoFeatures Features { get; set; } = SvoFeatures.All;
        public Type Underlying { get; set; } = typeof(string);
        public string Name { get; set; }
        public string FullName { get; set; }
        
        public string Namespace { get; set; } = "Qowaiv";

        public string Type
        {
            get => aliases.TryGetValue(Underlying, out var tp) ? tp : Underlying.FullName;
        }


        public bool HasFeature(SvoFeatures feature) => Features.HasFlag(feature);
        public bool LacksFeature(SvoFeatures feature) => !HasFeature(feature);

        private static readonly Dictionary<Type, string> aliases = new Dictionary<Type, string>
        {
            { typeof(byte), "byte" },
            { typeof(int), "int" },
            { typeof(string), "string" },
            { typeof(long), "long" },
            { typeof(DateTime), "DateTime" },
            { typeof(Guid), "Guid" },
        };
    }
}
