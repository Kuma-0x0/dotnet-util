using Utility.Process;

namespace Utility.Test.Process
{
    [TestClass]
    public class EnumerableUtilityTest
    {
        [TestMethod]
        public void AnyOrNotNull_01_Null_期待値_FALSE()
        {
            IEnumerable<int>? data = null;
            var actual = EnumerableUtility.AnyOrNotNull(data);
            Assert.IsFalse(actual);

            actual = data.AnyOrNotNull();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void AnyOrNotNull_02_空配列_期待値_FALSE()
        {
            var data = Array.Empty<int>();
            var actual = EnumerableUtility.AnyOrNotNull(data);
            Assert.IsFalse(actual);

            actual = data.AnyOrNotNull();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void AnyOrNotNull_03_空リスト_期待値_FALSE()
        {
            var data = new List<int>();
            var actual = EnumerableUtility.AnyOrNotNull(data);
            Assert.IsFalse(actual);

            actual = data.AnyOrNotNull();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void AnyOrNotNull_04_要素あり配列_期待値_TRUE()
        {
            var data = new int[] { 0, };
            var actual = EnumerableUtility.AnyOrNotNull(data);
            Assert.IsTrue(actual);

            actual = data.AnyOrNotNull();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void AnyOrNotNull_05_要素ありリスト_期待値_TRUE()
        {
            var data = new List<int>() { 0, };
            var actual = EnumerableUtility.AnyOrNotNull(data);
            Assert.IsTrue(actual);

            actual = data.AnyOrNotNull();
            Assert.IsTrue(actual);
        }
    }
}
