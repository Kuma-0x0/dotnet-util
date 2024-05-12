using Utility.Process;

namespace Utility.Test.Process;

[TestClass]
public class EnumerableUtilityTest
{
    #region AnyOrNotNull
    [TestMethod]
    public void AnyOrNotNull_Null_期待値_FALSE()
    {
        IEnumerable<int>? data = null;
        var actual = EnumerableUtility.AnyOrNotNull(data);
        Assert.IsFalse(actual);

        actual = data.AnyOrNotNull();
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void AnyOrNotNull_空配列_期待値_FALSE()
    {
        var data = Array.Empty<int>();
        var actual = EnumerableUtility.AnyOrNotNull(data);
        Assert.IsFalse(actual);

        actual = data.AnyOrNotNull();
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void AnyOrNotNull_空リスト_期待値_FALSE()
    {
        var data = new List<int>();
        var actual = EnumerableUtility.AnyOrNotNull(data);
        Assert.IsFalse(actual);

        actual = data.AnyOrNotNull();
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void AnyOrNotNull_要素あり配列_期待値_TRUE()
    {
        var data = new int[] { 0, };
        var actual = EnumerableUtility.AnyOrNotNull(data);
        Assert.IsTrue(actual);

        actual = data.AnyOrNotNull();
        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void AnyOrNotNull_要素ありリスト_期待値_TRUE()
    {
        var data = new List<int>() { 0, };
        var actual = EnumerableUtility.AnyOrNotNull(data);
        Assert.IsTrue(actual);

        actual = data.AnyOrNotNull();
        Assert.IsTrue(actual);
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

        var actual = await EnumerableUtility.SelectAsync(data, selector);
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
