using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoyalLondonTestApp;

namespace UnitTests
{
  [TestClass]
  public class MaturityDataTests
  {
    [TestMethod]
    public void PolicyTypeATest()
    {
      Dictionary<string, string> dict = new Dictionary<string, string>();

      dict.Add("policy_number", "A001");
      dict.Add("policy_start_date", "01/06/1986");
      dict.Add("premiums", "1000");
      dict.Add("membership", "Y");
      dict.Add("discretionary_bonus", "200");
      dict.Add("uplift_percentage", "40");

      MaturityData md = MaturityDataExtractor.Extractor(dict);

      Assert.AreEqual(md.PolicyType.Name, "A");
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 200);
      md.Membership = false;
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 200);
      md.PolicyStartDate = DateTime.Now;
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 0);
      md.Membership = true;
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 0);
    }

    [TestMethod]
    public void PolicyTypeBTest()
    {
      Dictionary<string, string> dict = new Dictionary<string, string>();

      dict.Add("policy_number", "B001");
      dict.Add("policy_start_date", "01/06/1986");
      dict.Add("premiums", "1000");
      dict.Add("membership", "Y");
      dict.Add("discretionary_bonus", "200");
      dict.Add("uplift_percentage", "40");

      MaturityData md = MaturityDataExtractor.Extractor(dict);

      Assert.AreEqual(md.PolicyType.Name, "B");
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 200);
      md.Membership = false;
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 0);
      md.PolicyStartDate = DateTime.Now;
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 0);
      md.Membership = true;
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 200);
    }

    [TestMethod]
    public void PolicyTypeCTest()
    {
      Dictionary<string, string> dict = new Dictionary<string, string>();

      dict.Add("policy_number", "C001");
      dict.Add("policy_start_date", "01/06/1986");
      dict.Add("premiums", "1000");
      dict.Add("membership", "Y");
      dict.Add("discretionary_bonus", "200");
      dict.Add("uplift_percentage", "40");

      MaturityData md = MaturityDataExtractor.Extractor(dict);

      Assert.AreEqual(md.PolicyType.Name, "C");
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 0);
      md.Membership = false;
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 0);
      md.PolicyStartDate = DateTime.Now;
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 0);
      md.Membership = true;
      Assert.AreEqual(md.QualifyingDiscretionaryBonus, 200);
    }
  }
}
