using Models.Results;
using System.Net;

namespace Models.Tests.Results;

[TestClass]
public class HttpResultFactoryTest
{
    [DataRow(200)]
    [DataRow(299)]
    [TestMethod]
    public void CreateSuccessResult(HttpStatusCode statusCode)
    {
        // Act
        var actual = HttpResultFactory.CreateSuccessResult(statusCode);

        // Assert
        Assert.IsTrue(actual.IsSuccess);
        Assert.AreEqual(statusCode, actual.StatusCode);
    }

    [TestMethod]
    public void CreateSuccessResult_value()
    {
        // Arrange
        var value = 1;

        // Act
        var actual = HttpResultFactory.CreateSuccessResult(HttpStatusCode.OK, value);

        // Assert
        Assert.IsTrue(actual.IsSuccess);
        Assert.AreEqual(HttpStatusCode.OK, actual.StatusCode);
        Assert.AreEqual(value, actual.Value);
    }

    [TestMethod]
    public void CreateWarningResult()
    {
        // Arrange
        var warning = "warning";

        // Act
        var actual = HttpResultFactory.CreateWarningResult<string>(HttpStatusCode.OK, warning);

        // Assert
        Assert.IsTrue(actual.IsSuccess);
        Assert.AreEqual(HttpStatusCode.OK, actual.StatusCode);
        Assert.AreEqual(warning, actual.Warning);
    }

    [TestMethod]
    public void CreateWarningResult_Value()
    {
        // Arrange
        var value = 1;
        var warning = "warning";

        // Act
        var actual = HttpResultFactory.CreateWarningResult(HttpStatusCode.OK, value, warning);

        // Assert
        Assert.IsTrue(actual.IsSuccess);
        Assert.AreEqual(HttpStatusCode.OK, actual.StatusCode);
        Assert.AreEqual(value, actual.Value);
        Assert.AreEqual(warning, actual.Warning);
    }

    [DataRow(199)]
    [DataRow(300)]
    [TestMethod]
    public void CreateErrorResult(int statusCode)
    {
        // Arrange
        var error = "error";

        // Act
        var actual = HttpResultFactory.CreateErrorResult((HttpStatusCode)statusCode, error);

        // Assert
        Assert.IsFalse(actual.IsSuccess);
        Assert.AreEqual((HttpStatusCode)statusCode, actual.StatusCode);
        Assert.AreEqual(error, actual.Error);
    }
}
