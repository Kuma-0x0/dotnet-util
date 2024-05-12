using System.Diagnostics.CodeAnalysis;

namespace Utility.Process;

public static class StringUtility
{
    /// <summary>
    /// 文字列が有効であるか検証する
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsValid([NotNullWhen(true)] this string? input) => !string.IsNullOrWhiteSpace(input);
}