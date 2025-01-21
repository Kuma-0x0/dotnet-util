namespace Extensions.Tests;

public class StringExtensionTest
{
    [Test]
    [Arguments(null)]
    [Arguments(" ")]
    [Arguments("\t")]
    [Arguments("\n")]
    [Arguments("\r")]
    [Arguments("\r\n")]
    [Arguments("")]
    public async Task IsValid_無効な文字列を入力する_期待値_FALSE(string? input)
    {
        await Assert.That(StringExtension.IsValid(input)).IsFalse();
        await Assert.That(input.IsValid()).IsFalse();
    }

    [Test]
    [Arguments("1")]
    [Arguments("a")]
    [Arguments("A")]
    [Arguments("あ")]
    [Arguments("ア")]
    public async Task IsValid_有効な文字列を入力する_期待値_TRUE(string? input)
    {
        await Assert.That(input.IsValid()).IsTrue();
    }
}
