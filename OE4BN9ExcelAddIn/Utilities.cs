using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE4BN9ExcelAddIn
{
   public class Utilities
   {
      public static string UppercaseFirst(string content)
      {
         if (string.IsNullOrEmpty(content))
         {
            return string.Empty;
         }

         char[] array = content.ToCharArray();

         array[0] = char.ToUpper(array[0]);

         return new string(array);
      }
   }
}
