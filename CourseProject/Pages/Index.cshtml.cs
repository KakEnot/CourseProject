using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using Microsoft.AspNetCore.Http;
using CourseProjekt;
using Syncfusion.DocIO.DLS;

namespace CourseProject.Pages
{
    public class IndexModel : PageModel
    {
        public string Text { get; set; }
        public static string Key { get; set; }
        public string Message2 { get; set; }
        public bool Locker = false;
        public static string Reuslt;

        public static string ErrorMessage { get; set; }

        public static string TempDocumentText { get; set; }

        public void OnPostUpload(IFormFile uploadfile)
        {
            if (uploadfile != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    uploadfile.CopyTo(ms);
                    TempDocumentText = DocumentService.PArseWordX(ms);
                }
                Locker = true;
                Text = TempDocumentText;
            }

        }

        public void OnPostText(string text, string key)
        {
            try
            {
                if (text == null) { text = ""; }
                else
                {
                    ErrorMessage = null;
                    if (TempDocumentText != null)
                    {
                        text = TempDocumentText;
                        Text = TempDocumentText;
                        TempDocumentText = null;
                    }
                    var cipher = new VigenereCipher(text, key);
                    Message2 = cipher.Decrypt();
                    Reuslt = Message2;
                    Text = text;
                    Key = key;
                }
            }
            catch (Exception)
            {
                ErrorMessage = "Уважаемый, вы не ввели ключ. Не надо так.";
                Text = text;
                Message2 = "";
            }
        }
        public FileResult OnPostExport()
        {
            //WordDocument document = new WordDocument(); //Add a section & a paragraph in the empty document
            //document.EnsureMinimal();  //Append text to the last paragraph of the document
            //document.LastParagraph.AppendText(Reuslt); //Save and close the Word document

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    document.Save(ms, Syncfusion.DocIO.FormatType.Docx);
            //    string fileName = "ResultFile.docx";
            //    return File(ms.ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            //}
        }
    }
}
