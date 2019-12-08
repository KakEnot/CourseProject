using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using System.Web;
using System.Net;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjekt

{
    public class DocumentService
    {
        public static string PArseWordX(Stream file)
        {
            //using (var doc = WordprocessingDocument.Open(@"C:\Users\Пушистая булка\Desktop\Учеба\Result_v5.docx", false))
            //using (var doc = WordprocessingDocument.Open(@"C:\Users\Admin\Desktop\Учеба\Result_v5.docx", false))
            using (var doc = WordprocessingDocument.Open(file, false))
            {
                var body = doc.MainDocumentPart.Document.Body.InnerText;
                return body;
            }
        }

       
    }
}
