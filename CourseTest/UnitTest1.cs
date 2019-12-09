using CourseProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Summing_TwoIntegers()
        {
            // Arrange 
            int a = 7;
            int b = 10;
            Program p = new Program();
            int sum = 17;
            
            //Act
            var result = p.Sum(a, b);//

            //Assert
            Assert.AreEqual(sum, result, "����� 7 � 10 �� ����� 17");
        }

        [TestMethod]
        public void Summing_TwoIntegers_MoreVar()
        {


            Assert.AreEqual(4, new Program().Sum(1,3), "�� ��������� ���������");
            Assert.AreEqual(14, new Program().Sum(11,3), "�� ��������� ���������");
            Assert.AreEqual(40, new Program().Sum(37,3), "�� ��������� ���������");
            Assert.AreEqual(-1, new Program().Sum(1,-2), "�� ��������� ��������� ������������� �����");
            Assert.AreEqual(0, new Program().Sum(0,0), "�� ��������� ���������");
            Assert.AreEqual(0, new Program().Sum(1,-1), "�� ��������� ���������");
            Assert.AreEqual(2, new Program().Sum(-1,3), "�� ��������� ���������");
            Assert.AreEqual(4, new Program().Sum(0,4), "�� ��������� ���������");
            Assert.AreEqual(100, new Program().Sum(100,0), "�� ��������� ���������");
        }
    }
}
