using System.Diagnostics.CodeAnalysis;

namespace Utility.Process;

public static class EnumerableUtility
{
    /// <summary>
    /// 要素が含まれているか
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool AnyOrNotNull<T>([NotNullWhen(true)]this IEnumerable<T>? input) => input?.Any() ?? false;

    /// <summary>
    /// <see cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/> の非同期版
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="input"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static async Task<IEnumerable<TResult>> SelectAsync<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, Task<TResult>> selector)
        => await Task.WhenAll(input.Select(selector));
}
