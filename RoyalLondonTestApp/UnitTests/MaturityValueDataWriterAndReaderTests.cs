using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoyalLondonTestApp;
using System.IO;

namespace UnitTests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class MaturityValueDataWriterAndReaderTests
  {
    public MaturityValueDataWriterAndReaderTests()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    //
    // You can use the following additional attributes as you write your tests:
    //
    // Use ClassInitialize to run code before running the first test in the class
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    [TestMethod]
    public void TestMethod1()
    {
      List<MaturityValueData> oldValues = new List<MaturityValueData>();

      oldValues.Add(new MaturityValueData() { PolicyNumber = "A001", MaturityValue = 100m });
      oldValues.Add(new MaturityValueData() { PolicyNumber = "B001", MaturityValue = 200m });

      string appDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.TestDir));
      string outputFilePath = Path.Combine(appDir, "UnitTests", "TestData", "output.xml");

      MaturityValueDataWriter maturityValueDataWriter = new MaturityValueDataWriter();

      maturityValueDataWriter.Write(oldValues, outputFilePath);

      MaturityValueDataReader maturityValueDataReader = new MaturityValueDataReader();

      List<MaturityValueData> newValues = maturityValueDataReader.ReadFile(outputFilePath);

      Assert.AreEqual(oldValues.Count, newValues.Count);

      for (int index = 0; index < oldValues.Count; ++index)
      {
        Assert.AreEqual(oldValues[index].PolicyNumber, newValues[index].PolicyNumber);
        Assert.AreEqual(oldValues[index].MaturityValue, newValues[index].MaturityValue);
      }
    }
  }
}
