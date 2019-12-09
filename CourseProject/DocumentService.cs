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
using Microsoft.AspNetCore.Hosting;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;

namespace CourseProjekt

{
    public class DocumentService
    {
        
     
        public static string PArseWordX(Stream file)
        {
    
            using (var doc = WordprocessingDocument.Open(file, false))
            {
                var body = doc.MainDocumentPart.Document.Body.InnerText;
                return body;
            }
        }

        public static FileResult SaveToDocx(string s)
        {
            WordDocument document = new WordDocument(); //Add a section & a paragraph in the empty document
            document.EnsureMinimal();  //Append text to the last paragraph of the document
            document.LastParagraph.AppendText(s); //Save and close the Word document

            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms, Syncfusion.DocIO.FormatType.Docx);
                string fileName = "ResultFile.docx";
                return File(ms.ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }

        }

       
    }
}
