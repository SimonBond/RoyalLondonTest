using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoyalLondonTestApp;

namespace UnitTests
{
  [TestClass]
  public class MaturityValueCalculatorTests
  {
    [TestMethod]
    public void TestMethod1()
    {
      MaturityValueCalculator mvc = new MaturityValueCalculator();

      Assert.AreEqual(mvc.Calculate(10000, 3, 1000, 40), 14980);
    }
  }
}
