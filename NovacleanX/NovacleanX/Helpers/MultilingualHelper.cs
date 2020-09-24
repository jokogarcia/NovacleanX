using System;
using System.Collections.Generic;
using System.Text;

namespace NovacleanX.Helpers
{
    public static class MultilingualHelper
    {
        public static string GetStringFromResource(object resourceObj, string propName)
        {
            try
            {
                return resourceObj.GetType().GetProperty(propName).GetValue(resourceObj, null).ToString();
            }
            catch
            {
                return "res:"+propName;
            }
            
        }
    }
}
