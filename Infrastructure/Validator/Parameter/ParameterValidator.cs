using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Validator.Parameter
{
    public static class ParameterValidator
    {

        public static void ValidateObject(object obj, string nameParameter, string customMessage = null)
        {
            if (obj == null) throw new ArgumentNullException(nameParameter, customMessage ?? $"The parameter {nameParameter} it is not null");
        }

        public static void ValidateString(string str, string nameParameter, string customMessage = null)
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException(nameParameter, customMessage ?? $"The parameter {nameParameter} it is not null/empty/white");
        }

        public static void ValidateEnumerable(IEnumerable enumerable, string nameParameter, string customMessage = null)
        {
            ValidateObject(enumerable, nameParameter);

            var nullItems = ToEnumerableObj(enumerable).Where(a => a == null);

            if (nullItems.Any()) throw new ArgumentNullException(nameParameter, customMessage ?? $"The colec-parameter {nameParameter} has not any null item");
        }


        public static void ValidateEnumerableString(IEnumerable<string> enumerable, string nameParameter, string customMessage = null)
        {
            ValidateObject(enumerable, nameParameter);

            var nullItems = enumerable.Where(string.IsNullOrWhiteSpace);

            if (nullItems.Any()) throw new ArgumentNullException(nameParameter, customMessage ?? $"The colec-parameter {nameParameter} has not any null/empty/white item");
        }
        private static IEnumerable<object> ToEnumerableObj(IEnumerable enumerable)
        {
            return enumerable.Cast<object>().ToList();
        }
    }
}
