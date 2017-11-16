namespace OE4BN9ExcelAddIn
{
   partial class JPMinderForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.mainTabControl = new System.Windows.Forms.TabControl();
         this.addWordsTabPage = new System.Windows.Forms.TabPage();
         this.addWordsButton = new System.Windows.Forms.Button();
         this.idSubjectTextBox = new System.Windows.Forms.TextBox();
         this.idSubjectLabel = new System.Windows.Forms.Label();
         this.createAndAddVocabulariesTabPage = new System.Windows.Forms.TabPage();
         this.subjectLabel = new System.Windows.Forms.Label();
         this.subjectNameTextBox = new System.Windows.Forms.TextBox();
         this.createSubjectAndAddVocabulariesButton = new System.Windows.Forms.Button();
         this.idCourseTextBox = new System.Windows.Forms.TextBox();
         this.idCourseLabel = new System.Windows.Forms.Label();
         this.accessTokenLabel = new System.Windows.Forms.Label();
         this.postVocabulariesWorker = new System.ComponentModel.BackgroundWorker();
         this.mainPanel = new System.Windows.Forms.Panel();
         this.accessTokenTextBox = new System.Windows.Forms.TextBox();
         this.mainTabControl.SuspendLayout();
         this.addWordsTabPage.SuspendLayout();
         this.createAndAddVocabulariesTabPage.SuspendLayout();
         this.mainPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // mainTabControl
         // 
         this.mainTabControl.Controls.Add(this.addWordsTabPage);
         this.mainTabControl.Controls.Add(this.createAndAddVocabulariesTabPage);
         this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.mainTabControl.Location = new System.Drawing.Point(0, 72);
         this.mainTabControl.Name = "mainTabControl";
         this.mainTabControl.SelectedIndex = 0;
         this.mainTabControl.Size = new System.Drawing.Size(304, 136);
         this.mainTabControl.TabIndex = 0;
         // 
         // addWordsTabPage
         // 
         this.addWordsTabPage.Controls.Add(this.addWordsButton);
         this.addWordsTabPage.Controls.Add(this.idSubjectTextBox);
         this.addWordsTabPage.Controls.Add(this.idSubjectLabel);
         this.addWordsTabPage.Location = new System.Drawing.Point(4, 22);
         this.addWordsTabPage.Name = "addWordsTabPage";
         this.addWordsTabPage.Padding = new System.Windows.Forms.Padding(3);
         this.addWordsTabPage.Size = new System.Drawing.Size(296, 110);
         this.addWordsTabPage.TabIndex = 0;
         this.addWordsTabPage.Text = "Add vocabularies";
         this.addWordsTabPage.UseVisualStyleBackColor = true;
         // 
         // addWordsButton
         // 
         this.addWordsButton.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.addWordsButton.Location = new System.Drawing.Point(3, 65);
         this.addWordsButton.Name = "addWordsButton";
         this.addWordsButton.Size = new System.Drawing.Size(290, 42);
         this.addWordsButton.TabIndex = 4;
         this.addWordsButton.Text = "Add";
         this.addWordsButton.UseVisualStyleBackColor = true;
         this.addWordsButton.Click += new System.EventHandler(this.addVocabulariesButton_Click);
         // 
         // idSubjectTextBox
         // 
         this.idSubjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.idSubjectTextBox.Location = new System.Drawing.Point(3, 23);
         this.idSubjectTextBox.Multiline = true;
         this.idSubjectTextBox.Name = "idSubjectTextBox";
         this.idSubjectTextBox.Size = new System.Drawing.Size(290, 36);
         this.idSubjectTextBox.TabIndex = 3;
         this.idSubjectTextBox.TextChanged += new System.EventHandler(this.idSubjectTextBox_TextChanged);
         // 
         // idSubjectLabel
         // 
         this.idSubjectLabel.AutoSize = true;
         this.idSubjectLabel.Location = new System.Drawing.Point(8, 3);
         this.idSubjectLabel.Name = "idSubjectLabel";
         this.idSubjectLabel.Size = new System.Drawing.Size(57, 13);
         this.idSubjectLabel.TabIndex = 2;
         this.idSubjectLabel.Text = "ID Subject";
         // 
         // createAndAddVocabulariesTabPage
         // 
         this.createAndAddVocabulariesTabPage.Controls.Add(this.subjectLabel);
         this.createAndAddVocabulariesTabPage.Controls.Add(this.subjectNameTextBox);
         this.createAndAddVocabulariesTabPage.Controls.Add(this.createSubjectAndAddVocabulariesButton);
         this.createAndAddVocabulariesTabPage.Controls.Add(this.idCourseTextBox);
         this.createAndAddVocabulariesTabPage.Controls.Add(this.idCourseLabel);
         this.createAndAddVocabulariesTabPage.Location = new System.Drawing.Point(4, 22);
         this.createAndAddVocabulariesTabPage.Name = "createAndAddVocabulariesTabPage";
         this.createAndAddVocabulariesTabPage.Padding = new System.Windows.Forms.Padding(3);
         this.createAndAddVocabulariesTabPage.Size = new System.Drawing.Size(296, 110);
         this.createAndAddVocabulariesTabPage.TabIndex = 1;
         this.createAndAddVocabulariesTabPage.Text = "Create subject and add vocabularies";
         this.createAndAddVocabulariesTabPage.UseVisualStyleBackColor = true;
         // 
         // subjectLabel
         // 
         this.subjectLabel.AutoSize = true;
         this.subjectLabel.Location = new System.Drawing.Point(153, 3);
         this.subjectLabel.Name = "subjectLabel";
         this.subjectLabel.Size = new System.Drawing.Size(74, 13);
         this.subjectLabel.TabIndex = 7;
         this.subjectLabel.Text = "Subject Name";
         // 
         // subjectNameTextBox
         // 
         this.subjectNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.subjectNameTextBox.Location = new System.Drawing.Point(151, 23);
         this.subjectNameTextBox.Multiline = true;
         this.subjectNameTextBox.Name = "subjectNameTextBox";
         this.subjectNameTextBox.Size = new System.Drawing.Size(142, 36);
         this.subjectNameTextBox.TabIndex = 6;
         this.subjectNameTextBox.TextChanged += new System.EventHandler(this.subjectName_TextChanged);
         // 
         // createSubjectAndAddVocabulariesButton
         // 
         this.createSubjectAndAddVocabulariesButton.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.createSubjectAndAddVocabulariesButton.Location = new System.Drawing.Point(3, 65);
         this.createSubjectAndAddVocabulariesButton.Name = "createSubjectAndAddVocabulariesButton";
         this.createSubjectAndAddVocabulariesButton.Size = new System.Drawing.Size(290, 42);
         this.createSubjectAndAddVocabulariesButton.TabIndex = 5;
         this.createSubjectAndAddVocabulariesButton.Text = "Add";
         this.createSubjectAndAddVocabulariesButton.UseVisualStyleBackColor = true;
         this.createSubjectAndAddVocabulariesButton.Click += new System.EventHandler(this.createSubjectAndAddVocabulariesButton_Click);
         // 
         // idCourseTextBox
         // 
         this.idCourseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.idCourseTextBox.Location = new System.Drawing.Point(3, 23);
         this.idCourseTextBox.Multiline = true;
         this.idCourseTextBox.Name = "idCourseTextBox";
         this.idCourseTextBox.Size = new System.Drawing.Size(142, 36);
         this.idCourseTextBox.TabIndex = 2;
         this.idCourseTextBox.TextChanged += new System.EventHandler(this.idCourseTextBox_TextChanged);
         // 
         // idCourseLabel
         // 
         this.idCourseLabel.AutoSize = true;
         this.idCourseLabel.Location = new System.Drawing.Point(8, 3);
         this.idCourseLabel.Name = "idCourseLabel";
         this.idCourseLabel.Size = new System.Drawing.Size(54, 13);
         this.idCourseLabel.TabIndex = 0;
         this.idCourseLabel.Text = "ID Course";
         // 
         // accessTokenLabel
         // 
         this.accessTokenLabel.AutoSize = true;
         this.accessTokenLabel.Location = new System.Drawing.Point(12, 9);
         this.accessTokenLabel.Name = "accessTokenLabel";
         this.accessTokenLabel.Size = new System.Drawing.Size(72, 13);
         this.accessTokenLabel.TabIndex = 0;
         this.accessTokenLabel.Text = "Access token";
         // 
         // postVocabulariesWorker
         // 
         this.postVocabulariesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.postVocabulariesWorker_DoWork);
         this.postVocabulariesWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.postVocabulariesWorker_ProgressChanged);
         this.postVocabulariesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.postVocabulariesWorker_RunWorkerCompleted);
         // 
         // mainPanel
         // 
         this.mainPanel.BackColor = System.Drawing.Color.White;
         this.mainPanel.Controls.Add(this.mainTabControl);
         this.mainPanel.Controls.Add(this.accessTokenLabel);
         this.mainPanel.Controls.Add(this.accessTokenTextBox);
         this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.mainPanel.Location = new System.Drawing.Point(0, 0);
         this.mainPanel.Name = "mainPanel";
         this.mainPanel.Size = new System.Drawing.Size(304, 208);
         this.mainPanel.TabIndex = 1;
         // 
         // accessTokenTextBox
         // 
         this.accessTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.accessTokenTextBox.Location = new System.Drawing.Point(7, 30);
         this.accessTokenTextBox.Multiline = true;
         this.accessTokenTextBox.Name = "accessTokenTextBox";
         this.accessTokenTextBox.Size = new System.Drawing.Size(290, 36);
         this.accessTokenTextBox.TabIndex = 1;
         this.accessTokenTextBox.TextChanged += new System.EventHandler(this.accessTokenTextBox_TextChanged);
         // 
         // JPMinderForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(304, 208);
         this.Controls.Add(this.mainPanel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.MaximizeBox = false;
         this.MinimumSize = new System.Drawing.Size(320, 240);
         this.Name = "JPMinderForm";
         this.Text = "Minder";
         this.TopMost = true;
         this.mainTabControl.ResumeLayout(false);
         this.addWordsTabPage.ResumeLayout(false);
         this.addWordsTabPage.PerformLayout();
         this.createAndAddVocabulariesTabPage.ResumeLayout(false);
         this.createAndAddVocabulariesTabPage.PerformLayout();
         this.mainPanel.ResumeLayout(false);
         this.mainPanel.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl mainTabControl;
      private System.Windows.Forms.TabPage addWordsTabPage;
      private System.Windows.Forms.TabPage createAndAddVocabulariesTabPage;
      private System.Windows.Forms.Label accessTokenLabel;
      private System.Windows.Forms.Button addWordsButton;
      private System.Windows.Forms.TextBox idSubjectTextBox;
      private System.Windows.Forms.Label idSubjectLabel;
      private System.ComponentModel.BackgroundWorker postVocabulariesWorker;
      private System.Windows.Forms.Panel mainPanel;
      private System.Windows.Forms.Label idCourseLabel;
      private System.Windows.Forms.Button createSubjectAndAddVocabulariesButton;
      private System.Windows.Forms.TextBox idCourseTextBox;
      private System.Windows.Forms.TextBox accessTokenTextBox;
      private System.Windows.Forms.Label subjectLabel;
      private System.Windows.Forms.TextBox subjectNameTextBox;
   }
}