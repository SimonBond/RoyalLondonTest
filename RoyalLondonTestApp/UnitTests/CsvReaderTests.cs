using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using RoyalLondonTestApp;

namespace UnitTests
{
  /// <summary>
  /// Summary description for CsvReaderTests
  /// </summary>
  [TestClass]
  public class CsvReaderTests
  {
    public CsvReaderTests()
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
      string appDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.TestDir));
      string filePath1 = Path.Combine(appDir, "UnitTests", "TestData", "test1.csv");

      Assert.IsTrue(File.Exists(filePath1));

      CsvReader csvReader = new CsvReader(',');

      foreach (Dictionary<string, string> dict in csvReader.Read(filePath1))
      {
        Assert.AreEqual(dict.Count, 4);
        Assert.AreEqual(dict["field1"], "one");
        Assert.AreEqual(dict["field2"], "two");
        Assert.AreEqual(dict["field3"], "three");
        Assert.AreEqual(dict["field4"], "four");
      }
    }
  }
}
