using Utility.Process;

namespace Utility.Test.Process
{
    [TestClass]
    public class StringUtilityTest
    {
        [DataRow(null)]
        [DataRow(" ")]
        [DataRow("\t")]
        [DataRow("\n")]
        [DataRow("\r")]
        [DataRow("\r\n")]
        [DataRow("")]
        [TestMethod]
        public void IsValid_01_�����ȕ��������͂���_���Ғl_FALSE(string? input)
        {
            // �N���X����Ăяo���B
            var actual = StringUtility.IsValid(input);
            Assert.IsFalse(actual);

            // �C���X�^���X����Ăяo���B
            actual = input.IsValid();
            Assert.IsFalse(actual);
        }

        [DataRow("1")]
        [DataRow("a")]
        [DataRow("A")]
        [DataRow("��")]
        [DataRow("�A")]
        [TestMethod]
        public void IsValid_02_�L���ȕ��������͂���_���Ғl_TRUE(string? input)
        {
            var actual = input.IsValid();
            Assert.IsTrue(input.IsValid());
        }
    }
}