using System;
using System.CodeDom;
using System.Collections.Generic;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.libUI.WinForms.UIDesigner
{
    public static class UIDesigner_Code
    {

        /// <summary>
        /// Adds the parameter to method.
        /// </summary>
        /// <param name="member1">The member1</param>
        /// <param name="paramType">The parameter type</param>
        /// <param name="paramName">The parameter name</param>
        public static void Method_AddParameter(CodeMemberMethod member1, string paramType, string paramName)
        {
            member1.Parameters.Add(new CodeParameterDeclarationExpression(paramType, paramName));
        }

        /// <summary>
        /// Adds the code to the method.
        /// </summary>
        /// <param name="member1">The member1</param>
        /// <param name="codeLine">The code line</param>
        /// <param name="isExpression">Is expression indicator. Default value = false.</param>
        public static void Method_AddCode(CodeMemberMethod member1, string codeLine, bool isExpression = false)
        {
            if (isExpression)
            {
                codeLine = codeLine.zSubStr_RemoveStrAtEnd(";");   // It will be added again
                var code2 = new CodeSnippetExpression(codeLine);
                member1.Statements.Add(code2);
            }
            else
            {
                var code1 = new CodeSnippetStatement(codeLine);
                member1.Statements.Add(code1);
            }
        }

        /// <summary>
        /// Find the code method.
        /// </summary>
        /// <param name="codeBackend">The code backend</param>
        /// <param name="method">Return the code member method</param>
        /// <param name="methodName">The method name</param>
        /// <param name="setScope">if set to <c>true</c> [set scope].</param>
        /// <param name="scope">The scope setting. Default value = MemberAttributes.Private.</param>
        /// <returns>
        /// bool
        /// </returns>
        public static bool Method_Find(CodeTypeDeclaration codeBackend, out CodeMemberMethod method, string methodName, bool setScope = false,
            MemberAttributes scope = MemberAttributes.Private)
        {
            var result = true;
            if (CodeMember_Find(codeBackend, methodName, out method) == false)
            {
                method = new CodeMemberMethod();
                method.Name = methodName;
                result = false;
            }

            if (setScope) method.Attributes = scope;
            return result;
        }

        /// <summary>
        /// Finds the code member.
        /// </summary>
        /// <param name="codeBackend">The code backend</param>
        /// <param name="memberName">The member name</param>
        /// <param name="member">Return the member</param>
        /// <returns>bool</returns>
        public static bool CodeMember_Find<T>(CodeTypeDeclaration codeBackend, string memberName, out T member) where T : CodeTypeMember
        {
            List<T> members = CodeMember_Find<T>(codeBackend);
            foreach (T member1 in members)
            {
                if (member1.Name == memberName)
                {
                    member = member1;
                    return true;
                }
            }
            member = null;
            return false;
        }

        /// <summary>
        /// Finds the code member for a spesific type.
        /// </summary>
        /// <param name="codeBackend">The code backend</param>
        /// <returns>List<T/></returns>
        public static List<T> CodeMember_Find<T>(CodeTypeDeclaration codeBackend) where T : CodeTypeMember
        {
            var result = new List<T>();
            CodeTypeMemberCollection members = codeBackend.Members;
            foreach (var member1 in members)
            {
                if ((member1 is T) == false) continue;
                result.Add((T)member1);
            }
            return result;
        }

        /// <summary>
        /// Generates the field in the code.
        /// </summary>
        /// <param name="codeBackend">The code backend</param>
        /// <param name="name">The name</param>
        /// <param name="type">The type</param>
        /// <param name="MemberAttributes">The member attributes setting. Default value = MemberAttributes.Public.</param>
        /// <param name="init">The initialize setting. Default value = null.</param>
        /// <returns>CodeMemberField</returns>
        public static CodeMemberField Field_Create(CodeTypeDeclaration codeBackend, String name, Type type, MemberAttributes MemberAttributes = MemberAttributes.Public,
            CodeExpression init = null)
        {
            var CodeMemberField = new CodeMemberField();
            CodeMemberField.Attributes = MemberAttributes;
            CodeMemberField.Type = new CodeTypeReference(type);
            CodeMemberField.Name = name;
            if (init != null) CodeMemberField.InitExpression = init;
            codeBackend.Members.Add(CodeMemberField);
            return CodeMemberField;
        }

        /// <summary>
        /// Creates the code property from the name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="type">The type</param>
        /// <returns>
        /// CodeMemberField
        /// </returns>
        private static CodeMemberField Property_Create(string propertyName, Type type)
        {
            // This is a little hack. Since you cant create auto properties in CodeDOM,
            //  we make the getter and setter part of the member name.
            // This leaves behind a trailing semicolon that we comment out.
            //  Later, we remove the commented out semicolons.
            string memberName = propertyName + "\t{ get; set; }//";

            var result = new CodeMemberField(type, memberName);
            result.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            return result;
        }
    }
}
