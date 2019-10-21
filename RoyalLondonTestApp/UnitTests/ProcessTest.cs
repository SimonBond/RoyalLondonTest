using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoyalLondonTestApp;
using System.IO;

namespace SystemTests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class ProcessTest
  {
    public ProcessTest()
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
      string fileName = Path.Combine(appDir, "UnitTests", "LiveData", "MaturityData.csv");

      MaturityValueCalculator maturityValueCalculator = new MaturityValueCalculator();
      DataReader<MaturityData> maturityDataReader = new DataReader<MaturityData>(MaturityDataExtractor.Extractor);
      Process process = new Process(maturityValueCalculator, maturityDataReader);

      try
      {
        process.ProcessFile(fileName);
      }
      catch
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    public void TestMethod2()
    {
      MaturityValueCalculator maturityValueCalculator = new MaturityValueCalculator();
      DataReader<MaturityData> maturityDataReader = new DataReader<MaturityData>(MaturityDataExtractor.Extractor);
      Process process = new Process(maturityValueCalculator, maturityDataReader);

      try
      {
        process.ProcessFile("C:\\RoyalLondon\\Projects\\Test\\RoyalLondonTestApp\\UnitTests\\LiveData\\ThisFileDoesNotExist.csv");
        Assert.Fail();
      }
      catch
      {
        // This is expected
      }
    }
  }
}
