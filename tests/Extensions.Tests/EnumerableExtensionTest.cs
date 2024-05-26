namespace Extension.Tests;

[TestClass]
public class EnumerableExtensionTest
{
    #region AnyOrNotNull
    [TestMethod]
    public void AnyOrNotNull_Null_期待値_FALSE()
    {
        IEnumerable<int>? data = null;
        Assert.IsFalse(EnumerableExtension.AnyOrNotNull(data));
        Assert.IsFalse(data.AnyOrNotNull());
    }

    [TestMethod]
    public void AnyOrNotNull_空配列_期待値_FALSE()
    {
        int[] data = [];
        Assert.IsFalse(EnumerableExtension.AnyOrNotNull(data));
        Assert.IsFalse(data.AnyOrNotNull());
    }

    [TestMethod]
    public void AnyOrNotNull_空リスト_期待値_FALSE()
    {
        List<int> data = [];
        Assert.IsFalse(EnumerableExtension.AnyOrNotNull(data));
        Assert.IsFalse(data.AnyOrNotNull());
    }

    [TestMethod]
    public void AnyOrNotNull_要素あり配列_期待値_TRUE()
    {
        int[] data = [0];
        Assert.IsTrue(EnumerableExtension.AnyOrNotNull(data));
        Assert.IsTrue(data.AnyOrNotNull());
    }

    [TestMethod]
    public void AnyOrNotNull_要素ありリスト_期待値_TRUE()
    {
        List<int> data = [0];
        Assert.IsTrue(EnumerableExtension.AnyOrNotNull(data));
        Assert.IsTrue(data.AnyOrNotNull());
    }
    #endregion

    #region SelectAsync
    [TestMethod]
    public async Task SelectAsync_クラスを呼び出し非同期処理を実行する_期待値_成功()
    {
        int[] data = [0, 1, 2, 3,];

        static async Task<string> selector(int value)
        {
            await Task.CompletedTask;
            return value.ToString();
        }

        var actual = await EnumerableExtension.SelectAsync(data, selector);
        string[] expected = ["0", "1", "2", "3",];

        Assert.AreEqual(data.Length, actual.Count());
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    [TestMethod]
    public async Task SelectAsync_拡張メソッドとして非同期処理を実行する_期待値_成功()
    {
        int[] data = [0, 1, 2, 3,];

        var actual = await data.SelectAsync(async x =>
        {
            await Task.CompletedTask;
            return x.ToString();
        });
        string[] expected = ["0", "1", "2", "3",];

        Assert.AreEqual(data.Length, actual.Count());
        Assert.IsTrue(expected.SequenceEqual(actual));
    }
    #endregion
}
