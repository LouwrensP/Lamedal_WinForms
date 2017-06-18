using System;

namespace Lamedal_UIWinForms.Enumerals
{

    [AttributeUsage(AttributeTargets.Field)]
    public sealed class enumValue_Attribute : Attribute
    {
        public readonly int intValue1 = -1;
        public readonly int intValue2 = -1;
        public readonly string strValue1 = null;
        public readonly string strValue2 = null;

        public enumValue_Attribute(int value1)
        {
            intValue1 = value1;
        }

        public enumValue_Attribute(int value1, int value2)
        {
            intValue1 = value1;
            intValue2 = value2;
        }

        public enumValue_Attribute(string value1)
        {
            strValue1 = value1;
        }

        public enumValue_Attribute(string value1, string value2)
        {
            strValue1 = value1;
            strValue2 = value2;
        }
    }
}