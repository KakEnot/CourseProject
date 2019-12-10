using CourseProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VignereEncrypt()
        {
            Assert.AreEqual("эпруч-шт, тбпд, тстй ау ёлхящ ыьдщдл, цамътаьвк фяуоюбы, цьеюгвхё эфпеюм?", new VigenereCipher("Скажи-ка, дядя, ведь не даром Москва, спаленная пожаром, Французу отдана?", "Лермонтов").Encrypt(), "Полученный текст не равен ожидаемому");
            Assert.AreEqual("", new VigenereCipher("", "Лермонтов").Encrypt(), "Полученный текст не равен ожидаемому");
            Assert.AreEqual("мчйкчнб фсъкс", new VigenereCipher("КОШАЧЬЯ ЛАПКА", "ВиСкАс").Encrypt(), "Полученный текст не равен ожидаемому");
            Assert.AreEqual("", new VigenereCipher("", "").Encrypt(), "Полученный текст не равен ожидаемому");
            Assert.AreNotEqual("крот", new VigenereCipher("КРот", "").Encrypt(), "Полученный текст не равен ожидаемому");
        }
        [TestMethod]
        public void VignereDecrypt()
        {
            Assert.AreEqual("", new VigenereCipher("", "").Decrypt());
            Assert.AreEqual("", new VigenereCipher("", "Лермонтов").Decrypt(), "Полученный текст не равен ожидаемому");
            Assert.AreEqual("кошачья лапка", new VigenereCipher("МЧЙКЧНБ ФСЪКС", "ВиСкАс").Decrypt(), "Полученный текст не равен ожидаемому");
            Assert.AreEqual("", new VigenereCipher("", "").Decrypt(), "Полученный текст не равен ожидаемому");
            Assert.AreNotEqual("крот", new VigenereCipher("КРот", "").Decrypt(), "Полученный текст не равен ожидаемому");
        }
    }
}
