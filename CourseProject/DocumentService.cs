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

        public void SaveToDocx(string s)
        {
          
        }
       
    }
}
