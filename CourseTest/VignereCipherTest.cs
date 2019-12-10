using CourseProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CourseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VignereEncryptTest()
        {
            Assert.AreEqual("������, ��������� �������", new VigenereCipher("������, ��������� �������", "���������").Encrypt());
            Assert.AreEqual("", new VigenereCipher("", "���������").Encrypt());
            Assert.AreEqual("������� �����", new VigenereCipher("������� �����", "������").Encrypt());
        }

        [TestMethod]
        public void VignereDecryptTest()
        {
            Assert.AreEqual("������, ��������� �������", new VigenereCipher("������, ��������� �������", "���������").Decrypt(), "���������� ����� �� ����� ����������");
            Assert.AreEqual("", new VigenereCipher("", "���������").Decrypt(), "���������� ����� �� ����� ����������");
            Assert.AreEqual("������� �����", new VigenereCipher("������� �����", "������").Decrypt(), "���������� ����� �� ����� ����������");
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
            byte[] file = File.ReadAllBytes("Result_v5.docx");
            using (MemoryStream ms = new MemoryStream(file))
            {
                Assert.AreEqual("����������, �� ������� �������� �����!", CourseProjekt.DocumentService.PArseWordX(ms));
            }
        }
    }
}
