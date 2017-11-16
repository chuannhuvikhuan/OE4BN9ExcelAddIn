using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE4BN9ExcelAddIn
{
   public class Subject
   {
      public string Name = string.Empty;
      public string Mean = string.Empty;

      public Subject(string name)
      {
         this.Name = name;
      }

      public string ToJsonPostData(string idCourse)
      {
         string result = null;

         JObject jsonResult = new JObject();

         string name = this.Name;

         jsonResult.Add("name", name);

         jsonResult.Add("id_course", idCourse);

         string mean = this.Mean;

         jsonResult.Add("mean", mean);

         result = jsonResult.ToString(Newtonsoft.Json.Formatting.None);

         return result;
      }
   }
}
