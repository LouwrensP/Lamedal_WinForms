using System;

namespace Lamedal_UIWinForms.Enumerals
{
    public static class enumValue_Controller
    {
        /// <summary>
        /// Function to get the value of the enumerator.
        /// </summary>
        /// <param name="enumValue">The enumber</param>
        /// <param name="value">The value.</param>
        /// <param name="attValue1">The att value1.</param>
        /// <param name="attValue2">The att value2.</param>
        /// <returns></returns>
        public static bool zValue_AsInt(this Enum enumValue, out int value, out int attValue1, out int attValue2)
        {
            // Usage:
            // Add [enumValue_(5,5)] flag to enumeral
            //
            //int value, attValue1, attValue2;
            //formType.zEnumValue_AsInt(out value, out attValue1, out attValue2);

            value = (int)(object)enumValue;
            var enumValueAttributes = (enumValue_Attribute[])(enumValue.GetType().GetField(enumValue.ToString())).GetCustomAttributes(typeof(enumValue_Attribute), false);
            if (enumValueAttributes.Length > 0)
            {
                attValue1 = enumValueAttributes[0].intValue1;
                attValue2 = enumValueAttributes[0].intValue2;
                return true;
            }

            attValue1 = -1;
            attValue2 = -1;
            return false;
        }

        /// <summary>
        /// Function to get the value of the enumerator.
        /// </summary>
        /// <param name="enumValue">The enumber</param>
        /// <param name="value">The value.</param>
        /// <param name="attValue1">The att value1.</param>
        /// <returns></returns>
        public static bool zValue_AsInt(this Enum enumValue, out int value, out int attValue1)
        {
            // Usage:
            // Add [enumValue_(5)] flag to enumeral
            //
            //int value, attValue1;
            //formType.zEnumValue_AsInt(out value, out attValue1);

            int attValue2;
            return zValue_AsInt(enumValue, out value, out attValue1, out attValue2);
        }

        /// <summary>
        /// Function to get the value of the enumerator.
        /// </summary>
        /// <param name="enumValue">The enumber</param>
        /// <param name="value">The value.</param>
        /// <param name="attValue1">The att value1.</param>
        /// <param name="attValue2">The att value2.</param>
        /// <returns></returns>
        public static bool zValue_AsStr(this Enum enumValue, out int value, out string attValue1, out string attValue2)
        {
            // Usage:
            // Add [enumValue_("value1","value2")] flag to enumeral
            //
            //int value; 
            //string attValue1, attValue2;
            //formType.zEnumValue_AsInt(out value, out attValue1, out attValue2);

            value = (int)(object)enumValue;
            var enumValueAttributes = (enumValue_Attribute[])(enumValue.GetType().GetField(enumValue.ToString())).GetCustomAttributes(typeof(enumValue_Attribute), false);
            if (enumValueAttributes.Length > 0)
            {
                attValue1 = enumValueAttributes[0].strValue1;
                attValue2 = enumValueAttributes[0].strValue2;
                return true;
            }

            attValue1 = null;
            attValue2 = null;
            return false;
        }

        /// <summary>
        /// Function to get the value of the enumerator.
        /// </summary>
        /// <param name="enumValue">The enumber</param>
        /// <param name="value">The value.</param>
        /// <param name="attValue1">The att value1.</param>
        /// <returns></returns>
        public static bool zValue_AsStr(this Enum enumValue, out int value, out string attValue1)
        {
            // Usage:
            // Add [enumValue_("value1")] flag to enumeral
            //
            //int value; 
            //string attValue1;
            //formType.zEnumValue_AsInt(out value, out attValue1);
            string attValue2;
            return zValue_AsStr(enumValue, out value, out attValue1, out attValue2);
        }
    }
}
