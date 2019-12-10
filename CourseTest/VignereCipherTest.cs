using CourseProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VignereEncryptTest()
        {
            Assert.AreEqual("шувчрн, дювчйюъом вэилхящ", new VigenereCipher("Москва, спаленная пожаром", "Лермонтов").Encrypt());
            Assert.AreEqual("", new VigenereCipher("", "Лермонтов").Encrypt());
            Assert.AreEqual("мчйкчнб фсъкс", new VigenereCipher("КОШАЧЬЯ ЛАПКА", "ВиСкАс").Encrypt());
        }

        [TestMethod]
        public void VignereDecryptTest()
        {
            Assert.AreEqual("москва, спаленная пожаром", new VigenereCipher("ШувчРн, дювчйюъОм вэилхящ", "Лермонтов").Decrypt(), "Полученный текст не равен ожидаемому");
            Assert.AreEqual("", new VigenereCipher("", "Лермонтов").Decrypt(), "Полученный текст не равен ожидаемому");
            Assert.AreEqual("кошачья лапка", new VigenereCipher("МЧЙКЧНБ ФСЪКС", "ВиСкАс").Decrypt(), "Полученный текст не равен ожидаемому");
        }

        [TestMethod]
        public void GetRepeatKeyTest()
        {
            Assert.AreEqual("qqqqq", VigenereCipher.GetRepeatKey("q", 5));
            Assert.AreEqual(5, VigenereCipher.GetRepeatKey("q", 5).Length);
            Assert.AreEqual(0, VigenereCipher.GetRepeatKey("q", 0).Length);
        }

        [TestMethod]
        public void PArseWordX()
        {
            string s = CourseProjekt.DocumentService.PArseWordX();
            string result = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!";
        }

        [TestMethod]
        public void OnPostUploadTest()
        {
            //public void OnPostUpload(IFormFile uploadfile)
            //{
            //    if (uploadfile != null)
            //    {
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            uploadfile.CopyTo(ms);
            //            TempDocumentText = DocumentService.PArseWordX(ms);
            //        }
            //        Locker = true;
            //        Text = TempDocumentText;
            //    }

            //}
        }

        [TestMethod]
        public void OnPostTextTest()
        {
            //public void OnPostText(string text, string key, bool operation)
            //{
            //    try
            //    {
            //        if (text == null) { text = ""; }
            //        else
            //        {
            //            ErrorMessage2 = null;
            //            if (TempDocumentText != null)
            //            {
            //                text = TempDocumentText;
            //                Text = TempDocumentText;
            //                TempDocumentText = null;
            //            }
            //            var cipher = new VigenereCipher(text, key);
            //            Operation = operation;

            //            if (Operation)
            //            {

            //                Result = cipher.Encrypt();
            //            }
            //            else
            //            {
            //                Result = cipher.Decrypt();
            //            }

            //            Text = text;
            //            Key = key;
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        ErrorMessage2 = "Уважаемый, вы не ввели ключ. Не надо так.";
            //        Text = text;
            //        Result = "";
            //    }
            //}
        }

        [TestMethod]

        public void OnPostExportTest()
        {
            //public FileResult OnPostExport()
            //{
            //    WordDocument document = new WordDocument(); //Add a section & a paragraph in the empty document
            //    document.EnsureMinimal();  //Append text to the last paragraph of the document
            //    document.LastParagraph.AppendText(Result); //Save and close the Word document

            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        document.Save(ms, Syncfusion.DocIO.FormatType.Docx);
            //        string fileName = "ResultFile.docx";
            //        return File(ms.ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            //    }
            //}

        }
    }
}
