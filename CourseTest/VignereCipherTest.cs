using CourseProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourseTest
{
    [TestClass]
    class VignereCipherTest
    {
        [TestMethod]
        public void VignereEncrypt()
        {
            string text = "Скажи-ка, дядя, ведь не даром Москва, спаленная пожаром, Французу отдана?";
            string key = "Лермонтов";
            string retext = "эпруч-шт, тбпд, тстй ау ёлхящ ыьдщдл, цамътаьвк фяуоюбы, цьеюгвхё эфпеюм?";
            VigenereCipher cipher = new VigenereCipher(text, key);
            string result = cipher.Encrypt();
            Assert.AreEqual(retext, result, "Полученный текст не равен ожидаемому");
        }
    }
}
