using Models.Results;

namespace Models.Tests.Results;

[TestClass]
public class ResultFactoryTest
{
    [TestMethod]
    public void CreateSuccessResult()
    {
        // Act
        var actual = ResultFactory.CreateSuccessResult();

        // Assert
        Assert.IsTrue(actual.IsSuccess);
    }

    [TestMethod]
    public void CreateSuccessResult_Value()
    {
        // Arrange
        var value = 1;

        // Act
        var actual = ResultFactory.CreateSuccessResult(value);

        // Assert
        Assert.IsTrue(actual.IsSuccess);
        Assert.AreEqual(value, actual.Value);
    }

    [TestMethod]
    public void CreateWarningResult()
    {
        // Arrange
        var warning = "warning";

        // Act
        var actual = ResultFactory.CreateWarningResult<string>(warning);

        // Assert
        Assert.IsTrue(actual.IsSuccess);
        Assert.AreEqual(warning, actual.Warning);
    }

    [TestMethod]
    public void CreateWarningResult_Value()
    {
        // Arrange
        var value = 1;
        var warning = "warning";

        // Act
        var actual = ResultFactory.CreateWarningResult(value, warning);

        // Assert
        Assert.IsTrue(actual.IsSuccess);
        Assert.AreEqual(value, actual.Value);
        Assert.AreEqual(warning, actual.Warning);
    }

    [TestMethod]
    public void CreateErrorResult()
    {
        // Arrange
        var error = "error";

        // Act
        var actual = ResultFactory.CreateErrorResult(error);

        // Assert
        Assert.IsFalse(actual.IsSuccess);
        Assert.AreEqual(error, actual.Error);
    }
}
