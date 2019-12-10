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
            byte[] file = File.ReadAllBytes("Result_v5.docx");
            using (MemoryStream ms = new MemoryStream(file))
            {
                Assert.AreEqual("бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!", CourseProjekt.DocumentService.PArseWordX(ms));
            }
        }
    }
}
