using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OE4BN9ExcelAddIn
{
   public class KanjiConverter
   {
      public static readonly string Host = @"http://nihongo.j-talk.com/";

      private string timestamp = string.Empty;
      private string uniqid = string.Empty;
      private string kanji = string.Empty;
      private string kana_output = "roumaji";

      private string GetHTML(string url)
      {
         string result = null;

         HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
         HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

         if (httpWebResponse.StatusCode == HttpStatusCode.OK)
         {
            using (Stream stream = httpWebResponse.GetResponseStream())
            {
               using (StreamReader streamReader = new StreamReader(stream))
               {
                  result = streamReader.ReadToEnd();
               }
            }
         }

         return result;
      }

      private bool GetHiddenInputData()
      {
         bool result = false;

         string htmlString = this.GetHTML(Host);

         if (htmlString != null)
         {
            HtmlDocument htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(htmlString);

            HtmlNode tempNode = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='timestamp']");

            this.timestamp = tempNode.Attributes["value"].Value;

            tempNode = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='uniqid']");

            this.uniqid = tempNode.Attributes["value"].Value;

            result = true;
         }

         return result;
      }

      private string GetResult()
      {
         string result = null;

         HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Host);

         string postData = string.Format("timestamp={0}&uniqid={1}&kanji={2}&Submit=Translate+Now&kanji_parts=unchanged&converter=spaced&kana_output={3}",
           this.timestamp,
           this.uniqid,
           this.kanji,
           this.kana_output);

         byte[] data = Encoding.ASCII.GetBytes(postData);

         httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
         httpWebRequest.Method = "POST";
         httpWebRequest.ContentType = "application/x-www-form-urlencoded";
         httpWebRequest.ContentLength = data.Length;
         httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.62 Safari/537.36";

         using (Stream stream = httpWebRequest.GetRequestStream())
         {
            stream.Write(data, 0, data.Length);

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
               string htmlString = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();

               HtmlDocument htmlDocument = new HtmlDocument();

               htmlDocument.LoadHtml(htmlString);

               HtmlNode tempNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='spaced']");

               result = tempNode.InnerText.ToLower().Trim();

               result = HttpUtility.HtmlDecode(result);

               result = result
                  .Replace("[?]", string.Empty)
                  .Replace("[ ", "[")
                  .Replace(" ]", "]")
                  .Replace("～", "~")
                  .Replace("~ ", "~")
                  .Replace("。", ".");
            }
         }

         return result;
      }

      public string GetRoumaji(string input)
      {
         string result = null;

         if (this.GetHiddenInputData())
         {
            this.kana_output = "roumaji";

            this.kanji = HttpUtility.UrlEncode(input);

            result = this.GetResult();
         }

         return result;
      }
   }
}
