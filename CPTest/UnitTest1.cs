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
            Assert.AreEqual("�����-��, ����, ���� �� ����� ������, ��������� �������, �������� ������?", new VigenereCipher("�����-��, ����, ���� �� ����� ������, ��������� �������, �������� ������?", "���������").Encrypt(), "���������� ����� �� ����� ����������");
            Assert.AreEqual("", new VigenereCipher("", "���������").Encrypt(), "���������� ����� �� ����� ����������");
            Assert.AreEqual("������� �����", new VigenereCipher("������� �����", "������").Encrypt(), "���������� ����� �� ����� ����������");
            Assert.AreEqual("", new VigenereCipher("", "").Encrypt(), "���������� ����� �� ����� ����������");
            Assert.AreNotEqual("����", new VigenereCipher("����", "").Encrypt(), "���������� ����� �� ����� ����������");
        }
        [TestMethod]
        public void VignereDecrypt()
        {
            Assert.AreEqual("", new VigenereCipher("", "").Decrypt());
            Assert.AreEqual("", new VigenereCipher("", "���������").Decrypt(), "���������� ����� �� ����� ����������");
            Assert.AreEqual("������� �����", new VigenereCipher("������� �����", "������").Decrypt(), "���������� ����� �� ����� ����������");
            Assert.AreEqual("", new VigenereCipher("", "").Decrypt(), "���������� ����� �� ����� ����������");
            Assert.AreNotEqual("����", new VigenereCipher("����", "").Decrypt(), "���������� ����� �� ����� ����������");
        }
    }
}
