using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Jil;

namespace WebApplication1.Formatters
{
    public class TypedDeserializers
    {
        private static readonly ConcurrentDictionary<Type, Func<TextReader, Options, object>> methods;
        private static readonly MethodInfo method = typeof(JSON).GetMethod("Deserialize", new[] { typeof(TextReader), typeof(Options) });

        static TypedDeserializers()
        {
            methods = new ConcurrentDictionary<Type, Func<TextReader, Options, object>>();
        }

        public static Func<TextReader, Options, object> GetTyped(Type type)
        {
            return methods.GetOrAdd(type, CreateDelegate);
        }

        private static Func<TextReader, Options, object> CreateDelegate(Type type)
        {
            return (Func<TextReader, Options, object>)method
                .MakeGenericMethod(type)
                .CreateDelegate(typeof(Func<TextReader, Options, object>));
        }
    }
}