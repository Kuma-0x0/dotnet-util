namespace Extensions.Tests;

public class EnumerableExtensionTest
{
    #region AnyOrNotNull
    [Test]
    public async Task AnyOrNotNull_Null_期待値_FALSE()
    {
        IEnumerable<int>? data = null;
        await Assert.That(EnumerableExtension.AnyOrNotNull(data)).IsFalse();
        await Assert.That(data.AnyOrNotNull()).IsFalse();
    }

    [Test]
    public async Task AnyOrNotNull_空配列_期待値_FALSE()
    {
        int[] data = [];
        await Assert.That(EnumerableExtension.AnyOrNotNull(data)).IsFalse();
        await Assert.That(data.AnyOrNotNull()).IsFalse();
    }

    [Test]
    public async Task AnyOrNotNull_空リスト_期待値_FALSE()
    {
        List<int> data = [];
        await Assert.That(EnumerableExtension.AnyOrNotNull(data)).IsFalse();
        await Assert.That(data.AnyOrNotNull()).IsFalse();
    }

    [Test]
    public async Task AnyOrNotNull_要素あり配列_期待値_TRUE()
    {
        int[] data = [0];
        await Assert.That(EnumerableExtension.AnyOrNotNull(data)).IsTrue();
        await Assert.That(data.AnyOrNotNull()).IsTrue();
    }

    [Test]
    public async Task AnyOrNotNull_要素ありリスト_期待値_TRUE()
    {
        List<int> data = [0];
        await Assert.That(EnumerableExtension.AnyOrNotNull(data)).IsTrue();
        await Assert.That(data.AnyOrNotNull()).IsTrue();
    }
    #endregion

    #region SelectAsync
    [Test]
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

        await Assert.That(data.Length).IsEqualTo(actual.Count());
        await Assert.That(expected.SequenceEqual(actual)).IsTrue();
    }

    [Test]
    public async Task SelectAsync_拡張メソッドとして非同期処理を実行する_期待値_成功()
    {
        int[] data = [0, 1, 2, 3,];

        var actual = await data.SelectAsync(async x =>
        {
            await Task.CompletedTask;
            return x.ToString();
        });
        string[] expected = ["0", "1", "2", "3",];

        await Assert.That(data.Length).IsEqualTo(actual.Count());
        await Assert.That(expected.SequenceEqual(actual)).IsTrue();
    }
    #endregion
}
