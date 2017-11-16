using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Web;

namespace OE4BN9ExcelAddIn
{
   public enum VocabularyProperties
   {
      Index = 1,
      Key,
      RefKey,
      Content,
      Furigana,
      Kana,
      Roumaji,
      Vietnamese,
      Group,
      LessonID,
      Mean,
      Count
   }

   public class Vocabulary
   {
      public string Index = string.Empty;
      public string Key = string.Empty;
      public string RefKey = string.Empty;
      public string Content = string.Empty;
      public string Furigana = string.Empty;
      public string Kana = string.Empty;
      public string Roumaji = string.Empty;
      public string Vietnamese = string.Empty;
      public string Group = string.Empty;
      public string LessonID = string.Empty;
      public string Mean = string.Empty;

      public Vocabulary(Excel.Range entry)
      {
         int size = (int)VocabularyProperties.Count;

         for (int i = 1; i <= size; i++)
         {
            Excel.Range cell = entry.Cells[1, i];

            string value = string.Empty;

            if (cell.Value2 != null)
            {
               value = cell.Value2.ToString();

               value = value.Trim();
            }

            if (!string.IsNullOrEmpty(value))
            {
               VocabularyProperties property = (VocabularyProperties)i;

               switch (property)
               {
                  case VocabularyProperties.Index:
                     {
                        this.Index = value;
                     }
                     break;

                  case VocabularyProperties.Key:
                     {
                        this.Key = value;
                     }
                     break;

                  case VocabularyProperties.RefKey:
                     {
                        this.RefKey = value;
                     }
                     break;

                  case VocabularyProperties.Content:
                     {
                        this.Content = value;
                     }
                     break;

                  case VocabularyProperties.Furigana:
                     {
                        this.Furigana = value;
                     }
                     break;

                  case VocabularyProperties.Kana:
                     {
                        this.Kana = value;
                     }
                     break;

                  case VocabularyProperties.Roumaji:
                     {
                        value = value.ToLower();

                        this.Roumaji = value;
                     }
                     break;

                  case VocabularyProperties.Vietnamese:
                     {
                        value = value.ToUpper();

                        this.Vietnamese = value;
                     }
                     break;

                  case VocabularyProperties.Group:
                     {
                        this.Group = value;
                     }
                     break;

                  case VocabularyProperties.LessonID:
                     {
                        this.LessonID = value;
                     }
                     break;

                  case VocabularyProperties.Mean:
                     {
                        value = Utilities.UppercaseFirst(value);

                        this.Mean = value;
                     }
                     break;

                  default:
                     {
                     }
                     break;
               }

               if (value != cell.Value2.ToString())
               {
                  cell.Value = value;
               }
            }
         }
      }

      public JObject ToJObject()
      {
         JObject result = new JObject();

         int size = (int)VocabularyProperties.Count;

         for (int i = 1; i <= size; i++)
         {
            VocabularyProperties property = (VocabularyProperties)i;

            switch (property)
            {
               case VocabularyProperties.Index:
                  {
                     //
                  }
                  break;

               case VocabularyProperties.Key:
                  {
                     result.Add("key", this.Key);
                  }
                  break;

               case VocabularyProperties.RefKey:
                  {
                     if (!string.IsNullOrEmpty(this.RefKey))
                     {
                        result.Add("refKey", this.RefKey);
                     }
                  }
                  break;

               case VocabularyProperties.Content:
                  {
                     if (!string.IsNullOrEmpty(this.Content))
                     {
                        result.Add("content", this.Content);
                     }
                  }
                  break;

               case VocabularyProperties.Furigana:
                  {
                     if (!string.IsNullOrEmpty(this.Furigana))
                     {
                        result.Add("furigana", this.Furigana);
                     }
                  }
                  break;

               case VocabularyProperties.Kana:
                  {
                     if (!string.IsNullOrEmpty(this.Kana))
                     {
                        result.Add("kana", this.Kana);
                     }
                  }
                  break;

               case VocabularyProperties.Roumaji:
                  {
                     if (!string.IsNullOrEmpty(this.Roumaji))
                     {
                        result.Add("roumaji", this.Roumaji);
                     }
                  }
                  break;

               case VocabularyProperties.Vietnamese:
                  {
                     if (!string.IsNullOrEmpty(this.Vietnamese))
                     {
                        result.Add("vietnamese", this.Vietnamese);
                     }
                  }
                  break;

               case VocabularyProperties.Group:
                  {
                     //
                  }
                  break;

               case VocabularyProperties.LessonID:
                  {
                     //
                  }
                  break;

               case VocabularyProperties.Mean:
                  {
                     if (!string.IsNullOrEmpty(this.Mean))
                     {
                        result.Add("mean", this.Mean);
                     }
                  }
                  break;

               default:
                  {
                  }
                  break;
            }
         }

         return result;
      }

      public string ToJsonPostData(string idSubject)
      {
         string result = null;

         JObject jsonResult = new JObject();

         jsonResult.Add("id_subject", idSubject);

         string word = this.Content
            .Replace(".", string.Empty)
            .Replace("～", "〜");

         jsonResult.Add("word", word);

         string mean = this.Mean;

         jsonResult.Add("mean", mean);

         string phonetic = this.Kana + "\r\n" + this.Roumaji;

         if (!string.IsNullOrEmpty(this.Vietnamese))
         {
            phonetic += "\r\n" + string.Format("「{0}」", this.Vietnamese);
         }

         jsonResult.Add("phonetic", phonetic);

         jsonResult.Add("example", string.Empty);
         jsonResult.Add("example_mean", string.Empty);

         result = jsonResult.ToString(Newtonsoft.Json.Formatting.None);

         return result;
      }
   }
}
