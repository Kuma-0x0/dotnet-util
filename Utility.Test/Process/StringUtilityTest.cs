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
        public void IsValid_01_無効な文字列を入力する_期待値_FALSE(string? input)
        {
            // クラスから呼び出し。
            var actual = StringUtility.IsValid(input);
            Assert.IsFalse(actual);

            // インスタンスから呼び出し。
            actual = input.IsValid();
            Assert.IsFalse(actual);
        }

        [DataRow("1")]
        [DataRow("a")]
        [DataRow("A")]
        [DataRow("あ")]
        [DataRow("ア")]
        [TestMethod]
        public void IsValid_02_有効な文字列を入力する_期待値_TRUE(string? input)
        {
            var actual = input.IsValid();
            Assert.IsTrue(actual);
        }
    }
}