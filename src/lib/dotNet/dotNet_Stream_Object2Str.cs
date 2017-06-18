using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.lib.dotNet
{
    /// <summary>
    /// Dumb all properties of an object to a string.
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_ActionData)]
    public sealed class dotNet_Stream_Object2Str
    {
        public readonly int MaxPropertyLength = 250;
        public readonly int MaxItemCount = 20;

        private int _level;
        private readonly int _indentSize;
        private readonly StringBuilder _stringBuilder;
        private readonly List<int> _hashListOfFoundElements;

        /// <summary>
        /// Initializes a new instance of the <see cref="dotNet_Stream_Object2Str"/> class.
        /// </summary>
        /// <param name="indentSize">Size of the indent.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="maxItemCount">The maximum item count.</param>
        private dotNet_Stream_Object2Str(int indentSize = 2, int maxLength = 250, int maxItemCount = 20)
        {
            _indentSize = indentSize;
            MaxPropertyLength = maxLength;
            MaxItemCount = maxItemCount;
            _stringBuilder = new StringBuilder();
            _hashListOfFoundElements = new List<int>();
        }

        /// <summary>
        /// Word_FromAbbreviation the specified object properties to printable string.
        /// </summary>
        /// <param name="classObject">The element.</param>
        /// <param name="indentSize">Size of the indent.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="maxItemCount">The maximum item count2.</param>
        /// <returns>System.String.</returns>
        public static string Object_AsStrFormated(object classObject, int indentSize = 2, int maxLength = 1000, int maxItemCount = 20)
        {
            var instance = new dotNet_Stream_Object2Str(indentSize, maxLength, maxItemCount);
            return instance.DumpElement(classObject);
        }

        #region private

        private string DumpElement(object element)
        {
            if (element == null || element is ValueType || element is string) Write(FormatValue(element));
            else
            {
                var objectType = element.GetType();
                if (!typeof(IEnumerable).IsAssignableFrom(objectType))
                {
                    Write("---------------------------------------------------------------------------");
                    Write("{{{0}}}", objectType.FullName);
                    Write("---------------------------------------------------------------------------");
                    _hashListOfFoundElements.Add(element.GetHashCode());
                    _level++;
                }

                var enumerableElement = element as IEnumerable;
                if (enumerableElement != null)
                {
                    var counter = 0;
                    foreach (var item in enumerableElement)
                    {
                        counter++;
                        if (counter > MaxItemCount)
                        {
                            Write("  //-------------[ etc...");
                            break;
                        }

                        if (item is IEnumerable && !(item is string))
                        {
                            _level++;
                            DumpElement(item);
                            _level--;
                        }
                        else
                        {
                            if (!AlreadyTouched(item)) DumpElement(item);
                            else Write("{{{0}}} <-- bidirectional reference found", item.GetType().FullName);
                        }
                    }
                }
                else
                {
                    var members = element.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var memberInfo in members)
                    {
                        var fieldInfo = memberInfo as FieldInfo;
                        var propertyInfo = memberInfo as PropertyInfo;

                        if (fieldInfo == null && propertyInfo == null) continue;

                        var type = fieldInfo != null ? fieldInfo.FieldType : propertyInfo.PropertyType;
                        var value = (fieldInfo != null) ? fieldInfo.GetValue(element) : propertyInfo.GetValue(element, null);

                        if (type.IsValueType || type == typeof(string))
                        {
                            Write("{0}: {1}", memberInfo.Name, FormatValue(value));
                        }
                        else
                        {
                            var isEnumerable = typeof(IEnumerable).IsAssignableFrom(type);
                            Write("{0}: {1}", memberInfo.Name, isEnumerable ? "..." : "{ }");

                            var alreadyTouched = !isEnumerable && AlreadyTouched(value);
                            _level++;
                            if (!alreadyTouched) DumpElement(value);
                            else Write("{{{0}}} <-- bidirectional reference found", value.GetType().FullName);

                            _level--;
                        }
                    }
                }

                if (!typeof(IEnumerable).IsAssignableFrom(objectType))
                {
                    _level--;
                }
            }

            return _stringBuilder.ToString();
        }

        private bool AlreadyTouched(object value)
        {
            if (value == null) return false;

            var hash = value.GetHashCode();
            for (var i = 0; i < _hashListOfFoundElements.Count; i++)
            {
                if (_hashListOfFoundElements[i] == hash) return true;
            }
            return false;
        }

        private void Write(string value, params object[] args)
        {
            var space = new string(' ', _level * _indentSize);

            if (args != null && args.Length > 0) value = string.Format(value, args);

            if (value.Length > MaxPropertyLength) value = value.Substring(0, MaxPropertyLength);
            if (value.Length > 250) value = "-----------------------------------".NL() + value;
            _stringBuilder.AppendLine(space + value);
        }

        private string FormatValue(object o)
        {
            if (o == null) return ("null");
            if (o is DateTime) return (((DateTime)o).ToShortDateString());
            if (o is string) return string.Format("\"{0}\"", o);
            if (o is char && (char)o == '\0') return string.Empty;
            if (o is ValueType) return (o.ToString());
            if (o is IEnumerable) return ("...");

            return ("{ }");
        }
        #endregion

    }
}