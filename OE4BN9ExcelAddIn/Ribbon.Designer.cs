namespace OE4BN9ExcelAddIn
{
   partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      public Ribbon()
          : base(Globals.Factory.GetRibbonFactory())
      {
         InitializeComponent();
      }

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.OE4BN9Tab = this.Factory.CreateRibbonTab();
         this.OptionsGroup = this.Factory.CreateRibbonGroup();
         this.FormatOnSaveCheckBox = this.Factory.CreateRibbonCheckBox();
         this.phpArrayButton = this.Factory.CreateRibbonButton();
         this.OE4BN9Tab.SuspendLayout();
         this.OptionsGroup.SuspendLayout();
         this.SuspendLayout();
         // 
         // OE4BN9Tab
         // 
         this.OE4BN9Tab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
         this.OE4BN9Tab.Groups.Add(this.OptionsGroup);
         this.OE4BN9Tab.Label = "OE4BN9";
         this.OE4BN9Tab.Name = "OE4BN9Tab";
         // 
         // OptionsGroup
         // 
         this.OptionsGroup.Items.Add(this.FormatOnSaveCheckBox);
         this.OptionsGroup.Items.Add(this.phpArrayButton);
         this.OptionsGroup.Label = "Options";
         this.OptionsGroup.Name = "OptionsGroup";
         // 
         // FormatOnSaveCheckBox
         // 
         this.FormatOnSaveCheckBox.Checked = true;
         this.FormatOnSaveCheckBox.Label = "Format on save";
         this.FormatOnSaveCheckBox.Name = "FormatOnSaveCheckBox";
         this.FormatOnSaveCheckBox.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.FormatOnSaveCheckBox_Click);
         // 
         // phpArrayButton
         // 
         this.phpArrayButton.Label = "PHP Array";
         this.phpArrayButton.Name = "phpArrayButton";
         this.phpArrayButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.phpArrayButton_Click);
         // 
         // Ribbon
         // 
         this.Name = "Ribbon";
         this.RibbonType = "Microsoft.Excel.Workbook";
         this.Tabs.Add(this.OE4BN9Tab);
         this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
         this.OE4BN9Tab.ResumeLayout(false);
         this.OE4BN9Tab.PerformLayout();
         this.OptionsGroup.ResumeLayout(false);
         this.OptionsGroup.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      internal Microsoft.Office.Tools.Ribbon.RibbonTab OE4BN9Tab;
      internal Microsoft.Office.Tools.Ribbon.RibbonGroup OptionsGroup;
      internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox FormatOnSaveCheckBox;
      internal Microsoft.Office.Tools.Ribbon.RibbonButton phpArrayButton;
   }

   partial class ThisRibbonCollection
   {
      internal Ribbon Ribbon
      {
         get { return this.GetRibbon<Ribbon>(); }
      }
   }
}
