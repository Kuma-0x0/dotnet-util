using Utility.Process;

namespace Utility.Test.Process;

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
    public void IsValid_無効な文字列を入力する_期待値_FALSE(string? input)
    {
        // クラスから呼び出し。
        Assert.IsFalse(StringUtility.IsValid(input));

        // 変数から呼び出し。
        Assert.IsFalse(input.IsValid());
    }

    [DataRow("1")]
    [DataRow("a")]
    [DataRow("A")]
    [DataRow("あ")]
    [DataRow("ア")]
    [TestMethod]
    public void IsValid_有効な文字列を入力する_期待値_TRUE(string? input)
    {
        Assert.IsTrue(input.IsValid());
    }
}
