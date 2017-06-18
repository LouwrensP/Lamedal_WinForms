using System.Diagnostics;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.Events
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.VS_Static)]
    public static class event_Handlers
    {
        /// <summary>Write status msg to the debug window.</summary>
        /// <param name="sender">The source of the event method</param>
        /// <param name="msg">The msg</param>
        /// <param name="index">The index</param>
        /// <param name="total">The total</param>
        /// <param name="cancel">Cancel indicator reference variable</param>
        public static void evMsgStatusbar_2Debug(object sender, string msg, int index, int total, ref bool cancel)
        {
            cancel = false;
            if (msg.zIsNullOrEmpty() == true) return;
            Debug.WriteLine(msg);
            1.zDoEvents();
        }

        /// <summary>Write status msg to the debug window.</summary>
        /// <param name="msg">The msg</param>
        public static void evMsg_2Debug(string msg)
        {
            if (msg.zIsNullOrEmpty() == true) return;
            Debug.WriteLine(msg);
            1.zDoEvents();
        }
    }
}
