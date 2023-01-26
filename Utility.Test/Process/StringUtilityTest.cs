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
        public void IsValid_01_クラスから呼び出し無効な文字列を入力する_期待値_FALSE(string? input)
        {
            var actual = StringUtility.IsValid(input);
            Assert.IsFalse(actual);
        }

        [DataRow(null)]
        [DataRow(" ")]
        [DataRow("")]
        [TestMethod]
        public void IsValid_02_拡張メソッドとして呼び出し無効な文字列を入力する_期待値_FALSE(string? input)
        {
            var actual = input.IsValid();
            Assert.IsFalse(actual);
        }

        [DataRow("1")]
        [DataRow("a")]
        [DataRow("A")]
        [DataRow("あ")]
        [DataRow("ア")]
        [TestMethod]
        public void IsValid_03_有効な文字列を入力する_期待値_TRUE(string? input)
        {
            var actual = input.IsValid();
            Assert.IsTrue(actual);
        }
    }
}