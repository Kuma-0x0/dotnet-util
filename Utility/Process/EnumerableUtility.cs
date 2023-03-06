namespace Utility.Process
{
    public static class EnumerableUtility
    {
        /// <summary>
        /// 要素が含まれているか。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool AnyOrNotNull<T>(this IEnumerable<T>? target) => target?.Any() ?? false;
    }
}
