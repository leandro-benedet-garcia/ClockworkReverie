using ClockworkReverie.CustomMath.DoubleNumerics;

namespace ClockworkReverie.CustomNumerics.Tests;

[TestClass]
public sealed class Vector2DTests
{
    [TestMethod]
    public void Creation()
    {
        const double X_VALUE1 = 125615.16500000001;
        const double Y_VALUE1 = 4648.486485999994;
        const double X_VALUE2 = 1.0;
        const double Y_VALUE2 = 1561.4140000000043;

        var firstVector = new Vector2D(X_VALUE1, Y_VALUE1);
        var secondVector = new Vector2D(X_VALUE2, Y_VALUE2);

        Assert.AreEqual(X_VALUE1, firstVector.X);
        Assert.AreEqual(Y_VALUE1, firstVector.Y);
        Assert.AreEqual(X_VALUE2, secondVector.X);
        Assert.AreEqual(Y_VALUE2, secondVector.Y);
    }
}
