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
        public static string Text { get; set; }
        public static string Key { get; set; }
        public bool Locker = false;
        public static string Result;
        public bool IsChecked { get; set; }
        public bool Operation { get; set; }
        public static string ErrorMessage { get; set; }
        public static string TempDocumentText { get; set; }
        static string defaultAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public void OnPostUpload(IFormFile uploadfile)
        {
            try
            {


                if (uploadfile != null)
                {
                    if (!uploadfile.FileName.EndsWith(".docx")) { throw new Exception("Программа работает только с .docx"); }
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ErrorMessage = null;
                        uploadfile.CopyTo(ms);
                        TempDocumentText = DocumentService.PArseWordX(ms);
                    }
                    Locker = true;
                    Text = TempDocumentText;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
               
            }

        }

        public void OnPostText(string text, string key, bool operation)
        {
            try
            {
                if (text == null) { throw new Exception("Уважаемый, переводить нечего. Текста нет."); }
                if (key == null) { throw new Exception("Уважаемый, вы не ввели ключ. Не надо так."); }
                if (key.ToLower().Any(x => !Char.IsLetter(x) || !defaultAlphabet.Contains(x))) { throw new Exception("Уважаемый, в ключе могут быть только русские буквы."); }

                ErrorMessage = null;
                if (TempDocumentText != null)
                {
                    text = TempDocumentText;
                    Text = TempDocumentText;
                    TempDocumentText = null;
                }
                var cipher = new VigenereCipher(text, key);
                Operation = operation;

                if (Operation)
                {

                    Result = cipher.Encrypt();
                }
                else
                {
                    Result = cipher.Decrypt();
                }

                Text = text;
                Key = key;
            }

            catch (Exception x)
            {
                ErrorMessage = x.Message;
                Text = text;
                Result = "";
            }
        }
        public FileResult OnPostExport()
        {
            WordDocument document = new WordDocument(); //Add a section & a paragraph in the empty document
            document.EnsureMinimal();  //Append text to the last paragraph of the document
            document.LastParagraph.AppendText(Result); //Save and close the Word document

            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms, Syncfusion.DocIO.FormatType.Docx);
                string fileName = "ResultFile.docx";
                return File(ms.ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
        }
    }
}
