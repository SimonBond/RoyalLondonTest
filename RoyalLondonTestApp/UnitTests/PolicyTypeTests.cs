using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoyalLondonTestApp;

namespace UnitTests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class PolicyTypeTests
  {
    public PolicyTypeTests()
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
      PolicyType ptA = PolicyType.GetPolicyType("A");
      PolicyType ptB = PolicyType.GetPolicyType("B");
      PolicyType ptC = PolicyType.GetPolicyType("C");

      MaturityData maturityData1 = new MaturityData("A001", new DateTime(1989, 1, 1), 10, false, 10, 10);
      Assert.IsTrue(ptA.QualifiesForDiscretionayBonus(maturityData1));
      Assert.IsFalse(ptB.QualifiesForDiscretionayBonus(maturityData1));
      Assert.IsFalse(ptC.QualifiesForDiscretionayBonus(maturityData1));

      MaturityData maturityData2 = new MaturityData("A001", new DateTime(1990, 1, 1), 10, false, 10, 10);
      Assert.IsFalse(ptA.QualifiesForDiscretionayBonus(maturityData2));
      Assert.IsFalse(ptB.QualifiesForDiscretionayBonus(maturityData2));
      Assert.IsFalse(ptC.QualifiesForDiscretionayBonus(maturityData2));

      MaturityData maturityData3 = new MaturityData("A001", new DateTime(1990, 1, 1), 10, true, 10, 10);
      Assert.IsFalse(ptA.QualifiesForDiscretionayBonus(maturityData3));
      Assert.IsTrue(ptB.QualifiesForDiscretionayBonus(maturityData3));
      Assert.IsTrue(ptC.QualifiesForDiscretionayBonus(maturityData3));

      MaturityData maturityData4 = new MaturityData("A001", new DateTime(1989, 1, 1), 10, true, 10, 10);
      Assert.IsTrue(ptA.QualifiesForDiscretionayBonus(maturityData4));
      Assert.IsTrue(ptB.QualifiesForDiscretionayBonus(maturityData4));
      Assert.IsFalse(ptC.QualifiesForDiscretionayBonus(maturityData4));
    }
  }
}
