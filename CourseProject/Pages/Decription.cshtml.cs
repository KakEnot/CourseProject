using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseProject.Pages
{
    public class DecriptionModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "������� ����� ��� ����������";

        }
        public void OnPost(string text)
        {
            var cipher = new VigenereCipher(text, "��������");
            Message = cipher.Decrypt();

        }

    }
}