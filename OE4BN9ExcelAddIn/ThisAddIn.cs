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

namespace OE4BN9ExcelAddIn
{
   public partial class ThisAddIn
   {
      public static readonly string ProjectName = "OE4BN9";

      public static readonly string FileName = "vocabularies.js";

      private Ribbon ribbon = null;

      private void ThisAddIn_Startup(object sender, System.EventArgs e)
      {
         this.ribbon = Globals.Ribbons.Ribbon;

         this.ResetCellMenu();

         this.Application.SheetBeforeRightClick += new Excel.AppEvents_SheetBeforeRightClickEventHandler(this.SheetBeforeRightClickEventHandler);

         this.Application.WorkbookBeforeSave += new Excel.AppEvents_WorkbookBeforeSaveEventHandler(this.WorkbookBeforeSaveEventHandler);
      }

      private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
      {
      }

      private void WorkbookBeforeSaveEventHandler(Excel.Workbook Wb, bool SaveAsUI, ref bool Cancel)
      {
         this.Save(this.GetContent(Wb));
      }

      private string GetContent(Excel.Workbook Wb)
      {
         string result = string.Empty;

         List<Excel.Worksheet> worksheets = this.GetProjectWorksheets(Wb);

         if (worksheets.Count > 0)
         {
            JObject jsonResult = new JObject();

            foreach (Excel.Worksheet worksheet in worksheets)
            {
               Excel.ListObject table = this.GetProjectTable(worksheet);

               if (table != null)
               {
                  this.GetJsonAndFormat(table, ref jsonResult);
               }
            }

            result += string.Format("{0}.vocabularies = {1};", ProjectName, jsonResult.ToString());
         }

         return result;
      }

      private Excel.ListObject GetProjectTable(Excel.Worksheet worksheet)
      {
         Excel.ListObject result = null;

         foreach (Excel.ListObject listObject in worksheet.ListObjects)
         {
            if (listObject.Name == ProjectName)
            {
               result = listObject;

               break;
            }
         }

         return result;
      }

      private List<Excel.Worksheet> GetProjectWorksheets(Excel.Workbook Wb)
      {
         List<Excel.Worksheet> result = new List<Excel.Worksheet>();

         foreach (Excel.Worksheet worksheet in Wb.Worksheets)
         {
            if (!worksheet.Name.StartsWith("_"))
            {
               result.Add(worksheet);
            }
         }

         return result;
      }

      private void GetJsonAndFormat(Excel.ListObject table, ref JObject jsonResult)
      {
         Excel.Range headerRow = table.HeaderRowRange;
         Excel.Range entries = table.Range.Rows;

         int columnsCount = headerRow.Columns.Count;
         int rowsCount = entries.Rows.Count;

         List<Vocabulary> listVocabularies = new List<Vocabulary>();

         for (int i = 2; i <= rowsCount; i++)
         {
            Excel.Range entry = entries[i];

            Vocabulary vocabulary = new Vocabulary(entry);

            if (listVocabularies.Count > 1)
            {
               Vocabulary previousVocabulary = listVocabularies[i - 3];

               if (vocabulary.Group != previousVocabulary.Group
                  || vocabulary.LessonID != previousVocabulary.LessonID)
               {
                  this.AddTopBorder(entry);
               }
               else
               {
                  //this.ClearBorder(entry);
               }
            }

            listVocabularies.Add(vocabulary);

            JToken token = jsonResult[vocabulary.Key];

            if (token == null)
            {
               jsonResult.Add(vocabulary.Key, vocabulary.ToJObject());
            }
            else
            {
               this.AddErrorBorder(entry);

               MessageBox.Show(string.Format("{0} is duplicate", vocabulary.Key));
            }
         }

         if (this.ribbon.FormatOnSaveCheckBox.Checked)
         {
            entries.AutoFit();
            entries.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
         }
      }

      public List<Vocabulary> GetListSelectedVocabularies()
      {
         Excel.Worksheet activeSheet = this.Application.ActiveSheet;

         Excel.Range selectedRange = this.Application.Selection;

         int columnsCount = selectedRange.Columns.Count;
         int rowsCount = selectedRange.Rows.Count;

         List<Vocabulary> result = new List<Vocabulary>();

         for (int i = 1; i <= rowsCount; i++)
         {
            Excel.Range cell = selectedRange.Cells[i, 1];

            Excel.Range entry = activeSheet.Rows[cell.Row];

            Vocabulary vocabulary = new Vocabulary(entry);

            result.Add(vocabulary);
         }

         return result;
      }

      private void AddTopBorder(Excel.Range entry)
      {
         Excel.Border topBorder = entry.Borders[Excel.XlBordersIndex.xlEdgeTop];

         topBorder.Color = 0x000000;
         topBorder.LineStyle = Excel.XlLineStyle.xlContinuous;
         topBorder.Weight = Excel.XlBorderWeight.xlThick;
      }

      private void ClearBorder(Excel.Range entry)
      {
         foreach (Excel.Border border in entry.Borders)
         {
            border.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
         }
      }

      private void AddErrorBorder(Excel.Range entry)
      {
         foreach (Excel.Border border in entry.Borders)
         {
            border.Color = 0x0000FF;
            border.LineStyle = Excel.XlLineStyle.xlDot;
            border.Weight = Excel.XlBorderWeight.xlThin;
         }
      }

      private void Save(string Content)
      {
         string directory = this.Application.ActiveWorkbook.Path + @"\js\";

         if (!Directory.Exists(directory))
         {
            Directory.CreateDirectory(directory);
         }

         using (StreamWriter streamWriter = new StreamWriter(directory + FileName))
         {
            streamWriter.WriteLine(Content);
         }
      }

      #region VSTO generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InternalStartup()
      {
         this.Startup += new System.EventHandler(ThisAddIn_Startup);
         this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
      }

      #endregion VSTO generated code
   }
}
