using Utility.Process;

namespace Utility.Test.Process
{
    [TestClass]
    public class StringUtilityTest
    {
        [DataRow(null)]
        [DataRow(" ")]
        [DataRow("")]
        [TestMethod]
        public void IsValid_01_�N���X����Ăяo�������ȕ��������͂���_���Ғl_FALSE(string? input)
        {
            var actual = StringUtility.IsValid(input);
            Assert.IsFalse(actual);
        }

        [DataRow(null)]
        [DataRow(" ")]
        [DataRow("")]
        [TestMethod]
        public void IsValid_02_�g�����\�b�h�Ƃ��ČĂяo�������ȕ��������͂���_���Ғl_FALSE(string? input)
        {
            var actual = input.IsValid();
            Assert.IsFalse(actual);
        }

        [DataRow("1")]
        [DataRow("a")]
        [DataRow("A")]
        [DataRow("��")]
        [DataRow("�A")]
        [TestMethod]
        public void IsValid_03_�L���ȕ��������͂���_���Ғl_TRUE(string? input)
        {
            var actual = input.IsValid();
            Assert.IsTrue(actual);
        }
    }
}