using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OE4BN9ExcelAddIn
{
   public partial class JPMinderForm : Form
   {
      public JPMinderForm()

      {
         InitializeComponent();

         LoadSettings();
      }

      private void LoadSettings()
      {
         this.accessTokenTextBox.Text = Properties.Settings.Default.AccessToken;

         this.idSubjectTextBox.Text = Properties.Settings.Default.IDSubject;

         this.idCourseTextBox.Text = Properties.Settings.Default.IDCourse;

         this.subjectNameTextBox.Text = Properties.Settings.Default.SubjectName;
      }

      private void accessTokenTextBox_TextChanged(object sender, EventArgs e)
      {
         Properties.Settings.Default.AccessToken = this.accessTokenTextBox.Text;

         Properties.Settings.Default.Save();
      }

      private void idSubjectTextBox_TextChanged(object sender, EventArgs e)
      {
         Properties.Settings.Default.IDSubject = this.idSubjectTextBox.Text;

         Properties.Settings.Default.Save();
      }

      private void idCourseTextBox_TextChanged(object sender, EventArgs e)
      {
         Properties.Settings.Default.IDCourse = this.idCourseTextBox.Text;

         Properties.Settings.Default.Save();
      }

      private void subjectName_TextChanged(object sender, EventArgs e)
      {
         Properties.Settings.Default.SubjectName = this.subjectNameTextBox.Text;

         Properties.Settings.Default.Save();
      }

      public void PostVocabulary(Vocabulary vocabulary)
      {
         string host = string.Format(
            "http://minder.vn/api/words/word?access_token={0}",
            this.accessTokenTextBox.Text.Trim());

         string idSubject = this.idSubjectTextBox.Text.Trim();

         string postData = vocabulary.ToJsonPostData(idSubject);

         byte[] data = Encoding.UTF8.GetBytes(postData);

         HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(host);

         httpWebRequest.Accept = "application/json, text/plain, */*";
         httpWebRequest.Method = "POST";
         httpWebRequest.ContentType = "application/json;charset=UTF-8";
         httpWebRequest.ContentLength = data.Length;
         httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36";

         using (Stream stream = httpWebRequest.GetRequestStream())
         {
            stream.Write(data, 0, data.Length);

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
            }
         }
      }

      private void postVocabulariesWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         List<Vocabulary> listVocabularies = Globals.ThisAddIn.GetListSelectedVocabularies();

         int size = listVocabularies.Count;

         for (int i = 0; i < size; i++)
         {
            if (this.postVocabulariesWorker.CancellationPending)
            {
               e.Cancel = true;

               break;
            }

            Vocabulary vocabulary = listVocabularies[i];

            this.PostVocabulary(vocabulary);

            this.Invoke((MethodInvoker)delegate ()
            {
               this.Text = string.Format("{0}/{1} Minder", i + 1, size);
            });
         }
      }

      private void postVocabulariesWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
      }

      private void postVocabulariesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         this.mainPanel.Invoke((MethodInvoker)delegate ()
         {
            this.mainPanel.Enabled = true;
         });
      }

      private void addVocabulariesButton_Click(object sender, EventArgs e)
      {
         this.mainTabControl.Enabled = false;

         this.postVocabulariesWorker.RunWorkerAsync();
      }

      private string CreateSubject()
      {
         string result = null;

         string subjectName = this.subjectNameTextBox.Text;

         if (string.IsNullOrEmpty(subjectName))
         {
            subjectName = DateTime.Now.ToString("MM/dd/yyyy");
         }

         Subject subject = new Subject(subjectName);

         string host = string.Format(
            "http://minder.vn/api/subjects/subject?access_token={0}",
            this.accessTokenTextBox.Text.Trim());

         string idCourse = this.idCourseTextBox.Text.Trim();

         string postData = subject.ToJsonPostData(idCourse);

         byte[] data = Encoding.UTF8.GetBytes(postData);

         HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(host);

         httpWebRequest.Accept = "application/json, text/plain, */*";
         httpWebRequest.Method = "POST";
         httpWebRequest.ContentType = "application/json;charset=UTF-8";
         httpWebRequest.ContentLength = data.Length;
         httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36";

         using (Stream stream = httpWebRequest.GetRequestStream())
         {
            stream.Write(data, 0, data.Length);

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
               string resultString = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();

               JObject jsonResult = JObject.Parse(resultString);

               result = jsonResult["Subject"]["id"].ToString();
            }
         }

         return result;
      }

      private void createSubjectAndAddVocabulariesButton_Click(object sender, EventArgs e)
      {
         this.mainPanel.Enabled = false;

         this.idSubjectTextBox.Invoke((MethodInvoker)delegate ()
         {
            this.idSubjectTextBox.Text = this.CreateSubject();
         });

         this.postVocabulariesWorker.RunWorkerAsync();
      }
   }
}
