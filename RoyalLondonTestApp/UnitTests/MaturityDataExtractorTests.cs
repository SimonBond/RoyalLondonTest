using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoyalLondonTestApp;

namespace UnitTests
{
  [TestClass]
  public class MaturityDataExtractorTests
  {
    [TestMethod]
    public void TestMethod1()
    {
      Dictionary<string, string> dict = new Dictionary<string, string>();

      dict.Add("policy_number", "A001");
      dict.Add("policy_start_date", "01/06/1986");
      dict.Add("premiums", "1000");
      dict.Add("membership", "Y");
      dict.Add("discretionary_bonus", "200");
      dict.Add("uplift_percentage", "40");

      MaturityData md = MaturityDataExtractor.Extractor(dict);

      Assert.AreEqual(md.PolicyNumber, "A001");
      Assert.AreEqual(md.PolicyStartDate.Day, 1);
      Assert.AreEqual(md.PolicyStartDate.Month, 6);
      Assert.AreEqual(md.PolicyStartDate.Year, 1986);
      Assert.AreEqual(md.Premiums, 1000);
      Assert.IsTrue(md.Membership);
      Assert.AreEqual(md.DiscretionaryBonus, 200);
      Assert.AreEqual(md.UpliftPercentage, 40);
    }
  }
}
