using System;
using System.Collections.Generic;
using System.Reflection;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace Lamedal_UIWinForms.lib.dotNet
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultGroup = "Attribute")]
    public sealed class dotNet_ClassAttribute
    {
        //private readonly LaMedalPort.UIWindows _uiWindows = LaMedalPort.UIWindows.Instance; // Instance to UIWindows
        //private readonly LaMedalPortable _lamed = LaMedalPortable.Instance;  // Create new instance of the blueprint library

        ///// <summary>
        ///// Determines with reflection whether the custom attributes array has attribute .
        ///// </summary>
        ///// <param name="customAttributes">The custom attributes array</param>
        ///// <param name="attribute">Return the attribute</param>
        ///// <param name="filterForThisAttribute">The filter for this attribute</param>
        ///// <returns>bool</returns>
        //public bool Attribute_Find(Attribute[] customAttributes, out Attribute attribute, Type filterForThisAttribute)
        //{
        //    attribute = null;
        //    foreach (Attribute attribute1 in customAttributes)
        //    {
        //        if (attribute1.GetType() == filterForThisAttribute)
        //        {
        //            attribute = attribute1;
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Determines with reflectionwhether the member information has a specific attribute .
        ///// </summary>
        ///// <param name="member">The member information</param>
        ///// <param name="attribute">Return the attribute</param>
        ///// <param name="filterForThisAttribute">The filter for this attribute</param>
        ///// <returns>bool</returns>
        //public bool ClassMember_FindAttribute(MemberInfo member, out Attribute attribute, Type filterForThisAttribute)
        //{
        //    var attributes = Attribute.GetCustomAttributes(member);
        //    return Attribute_Find(attributes, out attribute, filterForThisAttribute);
        //}

        ///// <summary>
        ///// Determines whether the class field type has attribute.
        ///// </summary>
        ///// <param name="classType">The class type</param>
        ///// <param name="attribute">The attribute reference variable</param>
        ///// <param name="filterForThisAttribute">The filter for this attribute</param>
        ///// <returns>bool</returns>
        //public bool Field_FindAttribute(Type classType, ref Attribute attribute, Type filterForThisAttribute)
        //{
        //    // The attribute was not on the methods -> test the fields
        //    FieldInfo[] fields = _uiWindows.Types.Generic.Class_Fields(classType);
        //    foreach (FieldInfo field in fields)
        //    {
        //        if (ClassMember_FindAttribute(field, out attribute, filterForThisAttribute)) return true;
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Determines whether the class field type has attribute.
        ///// </summary>
        ///// <param name="classType">The class type</param>
        ///// <param name="filterForThisAttribute">The filter for this attribute</param>
        ///// <param name="getAllFields">if set to <c>true</c> [get all fields].</param>
        ///// <returns></returns>
        //public List<Tuple<FieldInfo, Attribute>> Field_FindAttributes(Type classType, Type filterForThisAttribute, bool getAllFields = false)
        //{
        //    // The attribute was not on the methods -> test the fields
        //    var result = new List<Tuple<FieldInfo, Attribute>>();
        //    FieldInfo[] fields = _uiWindows.Types.Generic.Class_Fields(classType);
        //    foreach (FieldInfo field in fields)
        //    {
        //        Attribute attribute;
        //        if (ClassMember_FindAttribute(field, out attribute, filterForThisAttribute)) result.Add(new Tuple<FieldInfo, Attribute>(field, attribute));
        //        else
        //        {
        //            if (getAllFields) result.Add(new Tuple<FieldInfo, Attribute>(field, null));
        //        }
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// Determines whether the class method has attribute.
        ///// </summary>
        ///// <param name="classType">The class type</param>
        ///// <param name="attribute">The attribute reference variable</param>
        ///// <param name="filterForThisAttribute">The filter for this attribute</param>
        ///// <returns>bool</returns>
        //public bool Method_FindAttribute(Type classType, ref Attribute attribute, Type filterForThisAttribute)
        //{
        //    // The attribute was not on the type -> test the methods
        //    IEnumerable<MethodInfo> methods = _uiWindows.Types.Generic.Class_Methods(classType);
        //    foreach (MethodInfo method in methods)
        //    {
        //        if (ClassMember_FindAttribute(method, out attribute, filterForThisAttribute)) return true;
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Determines whether the class constructor has attribute.
        ///// </summary>
        ///// <param name="classType">The class type</param>
        ///// <param name="attribute">The attribute reference variable</param>
        ///// <param name="filterForThisAttribute">The filter for this attribute</param>
        ///// <returns>bool</returns>
        //public bool Constructor_FindAttribute(Type classType, ref Attribute attribute, Type filterForThisAttribute)
        //{
        //    // The attribute was not on the type -> test the methods
        //    ConstructorInfo[] constructors = _uiWindows.Types.Generic.Class_Constructors(classType);
        //    foreach (ConstructorInfo constructor in constructors)
        //    {
        //        if (ClassMember_FindAttribute(constructor, out attribute, filterForThisAttribute)) return true;
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Determines whether the object has attribute.
        ///// </summary>
        ///// <param name="Object">The object</param>
        ///// <param name="attribute">Return the attribute</param>
        ///// <param name="filterForThisAttribute">The filter for this attribute</param>
        ///// <returns>bool</returns>
        //public enAttributeLocation Object_FindAttribute(object Object, out Attribute attribute, Type filterForThisAttribute)
        //{
        //    Type classType = Object.GetType();
        //    return Type_FindAttribute(classType, out attribute, filterForThisAttribute);
        //}

        ///// <summary>
        ///// Determines with reflection whether the type has a specific attribute  type.
        ///// </summary>
        ///// <param name="classType">Type of the class.</param>
        ///// <param name="attribute">Return the attribute</param>
        ///// <param name="filterForThisAttribute">The filter for this attribute</param>
        ///// <returns>
        ///// eAttributeLocation
        ///// </returns>
        //public enAttributeLocation Type_FindAttribute(Type classType, out Attribute attribute, Type filterForThisAttribute)
        //{
        //    if (ClassMember_FindAttribute(classType, out attribute, filterForThisAttribute)) return enAttributeLocation.ClassAttribute;

        //    // The attribute was not on the type -> test the methods
        //    if (Method_FindAttribute(classType, ref attribute, filterForThisAttribute)) return enAttributeLocation.MethodAttribute;

        //    if (Field_FindAttribute(classType, ref attribute, filterForThisAttribute)) return enAttributeLocation.FieldAttribute;

        //    // The attribute was not on the fields -> test the properties
        //    if (Property_FindAttribute(classType, ref attribute, filterForThisAttribute)) return enAttributeLocation.PropertyAttribute;

        //    // The attribute was not on the constructor -> test the properties
        //    if (Constructor_FindAttribute(classType, ref attribute, filterForThisAttribute)) return enAttributeLocation.ConstructionAttribute;

        //    return enAttributeLocation.None;
        //}

        ///// <summary>
        ///// Determines with reflection whether the type has a specific attribute  type.
        ///// </summary>
        ///// <param name="classType">Type of the class.</param>
        ///// <param name="attribute">Return the attribute</param>
        ///// <returns>
        ///// eAttributeLocation
        ///// </returns>
        //public enAttributeLocation Type_FindAttribute<T>(Type classType, out T attribute) where T : Attribute
        //{
        //    var type = typeof(T);
        //    Attribute attribute1;
        //    var result = Type_FindAttribute(classType, out attribute1, type);
        //    attribute = (T)attribute1;
        //    return result;
        //}

        ///// <summary>
        ///// Determines whether the class property has attribute .
        ///// </summary>
        ///// <param name="classType">The class type</param>
        ///// <param name="attribute">The attribute reference variable</param>
        ///// <param name="filterForThisAttribute">The filter for this attribute</param>
        ///// <returns>bool</returns>
        //private bool Property_FindAttribute(Type classType, ref Attribute attribute, Type filterForThisAttribute)
        //{
        //    // The attribute was not on the fields -> test the properties
        //    PropertyInfo[] properties = _uiWindows.Types.Generic.Class_Properties(classType);
        //    foreach (PropertyInfo property in properties)
        //    {
        //        if (ClassMember_FindAttribute(property, out attribute, filterForThisAttribute)) return true;
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Return all the class properties with this attribute .
        ///// </summary>
        ///// <param name="classType">The class type</param>
        ///// <param name="attribute">The attribute reference variable</param>
        ///// <param name="filterForThisAttribute">The filter for this attribute</param>
        ///// <returns>bool</returns>
        //private List<PropertyInfo> Property_FindAttributes(Type classType, ref Attribute attribute, Type filterForThisAttribute)
        //{
        //    // The attribute was not on the fields -> test the properties
        //    var result = new List<PropertyInfo>();
        //    PropertyInfo[] properties = _uiWindows.Types.Generic.Class_Properties(classType);
        //    foreach (PropertyInfo property in properties)
        //    {
        //        if (ClassMember_FindAttribute(property, out attribute, filterForThisAttribute)) result.Add(property);
        //    }
        //    return result;
        //}
    }
}
