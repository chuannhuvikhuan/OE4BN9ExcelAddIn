using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace OE4BN9ExcelAddIn
{
   public partial class Ribbon
   {
      private ThisAddIn thisAddIn = null;

      private void Ribbon_Load(object sender, RibbonUIEventArgs e)
      {
         thisAddIn = Globals.ThisAddIn;

         FormatOnSaveCheckBox.Checked = Properties.Settings.Default.FormatOnSave;
      }

      private void FormatOnSaveCheckBox_Click(object sender, RibbonControlEventArgs e)
      {
         Properties.Settings.Default.FormatOnSave = FormatOnSaveCheckBox.Checked;

         Properties.Settings.Default.Save();
      }

      private void phpArrayButton_Click(object sender, RibbonControlEventArgs e)
      {
         this.thisAddIn.GetPHPArray();
      }
   }
}
