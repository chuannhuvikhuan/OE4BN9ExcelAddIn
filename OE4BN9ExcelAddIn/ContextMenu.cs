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
      private Office.CommandBar GetCellContextMenu()
      {
         return this.Application.CommandBars["List Range Popup"];
      }

      private void ResetCellMenu()
      {
         GetCellContextMenu().Reset();
      }

      private void SheetBeforeRightClickEventHandler(object Sh, Excel.Range Target, ref bool Cancel)
      {
         this.ResetCellMenu();

         this.AddExampleMenuItem();
      }

      private void AddExampleMenuItem()
      {
         Office.CommandBarPopup projectMenu = (Office.CommandBarPopup)
            GetCellContextMenu().Controls.Add(
               Office.MsoControlType.msoControlPopup,
               missing, missing, 1, true);

         projectMenu.Caption = ProjectName;

         Office.CommandBarButton reindexButton = (Office.CommandBarButton)
           projectMenu.Controls.Add(
              Office.MsoControlType.msoControlButton,
              missing, missing, missing, true);

         reindexButton.Caption = "Reindex";

         reindexButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(this.OnClickReindexButton);

         Office.CommandBarButton roumanjiButton = (Office.CommandBarButton)
            projectMenu.Controls.Add(
               Office.MsoControlType.msoControlButton,
               missing, missing, missing, true);

         roumanjiButton.Caption = "Roumaji";

         roumanjiButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(this.OnClickRoumajiButton);

         Office.CommandBarButton getPHPArrayButton = (Office.CommandBarButton)
            projectMenu.Controls.Add(
               Office.MsoControlType.msoControlButton,
               missing, missing, missing, true);

         getPHPArrayButton.Caption = "Get PHP Array";

         getPHPArrayButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(this.OnClickGetPHPArray);

         Office.CommandBarButton minderButton = (Office.CommandBarButton)
            projectMenu.Controls.Add(
               Office.MsoControlType.msoControlButton,
               missing, missing, missing, true);

         minderButton.Caption = "Minder";

         minderButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(this.OnClickMinderButton);
      }

      private void OnClickReindexButton(Office.CommandBarButton Ctrl, ref bool CancelDefault)
      {
         Excel.Worksheet activeSheet = this.Application.ActiveSheet;

         Excel.ListObject table = this.GetProjectTable(activeSheet);

         if (table != null)
         {
            this.Reindex(table);
         }
      }

      private void Reindex(Excel.ListObject table)
      {
         Excel.Range headerRow = table.HeaderRowRange;
         Excel.Range entries = table.Range.Rows;

         int columnsCount = headerRow.Columns.Count;
         int rowsCount = entries.Rows.Count;

         List<Vocabulary> listVocabularies = new List<Vocabulary>();

         int index = 1;

         for (int i = 2; i <= rowsCount; i++)
         {
            Excel.Range entry = entries[i];

            Excel.Range indexCell = entry.Cells[1, VocabularyProperties.Index];

            indexCell.Value = index.ToString();

            index++;
         }

         if (this.ribbon.FormatOnSaveCheckBox.Checked)
         {
            entries.AutoFit();
            entries.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
         }
      }

      private void OnClickRoumajiButton(Office.CommandBarButton Ctrl, ref bool CancelDefault)
      {
         this.SetRoumaji();
      }

      public void SetRoumaji()
      {
         Excel.Worksheet activeSheet = this.Application.ActiveSheet;

         Excel.Range selectedRange = this.Application.Selection;

         int rowsCount = selectedRange.Rows.Count;

         for (int i = 1; i <= rowsCount; i++)
         {
            Excel.Range cell = selectedRange.Cells[i, 1];

            Excel.Range contentCell = activeSheet.Cells[cell.Row, VocabularyProperties.Content];

            Excel.Range roumajiCell = activeSheet.Cells[cell.Row, VocabularyProperties.Roumaji];

            string input = contentCell.Value2.ToString();

            input = input.Replace(".", string.Empty);

            KanjiConverter kanjiConverter = new KanjiConverter();

            string result = kanjiConverter.GetRoumaji(input);

            if (result != null)
            {
               roumajiCell.Value = result;
            }
         }
      }

      private void OnClickGetPHPArray(Office.CommandBarButton Ctrl, ref bool CancelDefault)
      {
         this.GetPHPArray();
      }

      public void GetPHPArray()
      {
         string result = string.Empty;

         string group = null;

         Excel.Worksheet activeSheet = this.Application.ActiveSheet;

         Excel.Range selectedRange = this.Application.Selection;

         int columnsCount = selectedRange.Columns.Count;
         int rowsCount = selectedRange.Rows.Count;

         for (int i = 1; i <= rowsCount; i++)
         {
            Excel.Range cell = selectedRange.Cells[i, 1];

            Excel.Range keyCell = activeSheet.Cells[cell.Row, VocabularyProperties.Key];

            Excel.Range groupCell = activeSheet.Cells[cell.Row, VocabularyProperties.Group];

            string key = keyCell.Value2.ToString();

            string cellGroup = groupCell.Value2.ToString();

            if (group != cellGroup)
            {
               if (group != null)
               {
                  result = result.Substring(0, result.Length - 2);

                  result += "\r\n),\r\n";
               }

               group = cellGroup;

               result += string.Format("array(//{0}\r\n", group);
            }

            result += string.Format("'{0}', ", key);
         }

         result = result.Substring(0, result.Length - 2);
         result += "\r\n),";

         Clipboard.SetText(result);
      }

      private void OnClickMinderButton(Office.CommandBarButton Ctrl, ref bool CancelDefault)
      {
         this.OpenMiderForm();
      }

      public void OpenMiderForm()
      {
         JPMinderForm form = new JPMinderForm();

         form.Show();
      }
   }
}
