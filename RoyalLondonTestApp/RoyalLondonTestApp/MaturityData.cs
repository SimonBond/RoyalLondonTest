using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalLondonTestApp
{
  public class MaturityData
  {
    public string PolicyNumber;
    public DateTime PolicyStartDate;
    public decimal Premiums;
    public bool Membership;
    public decimal DiscretionaryBonus;
    public decimal UpliftPercentage;
    public decimal QualifyingDiscretionaryBonus
    {
      get
      {
        return PolicyType.QualifiesForDiscretionayBonus(this) ? DiscretionaryBonus : decimal.Zero;
      }
    }

    public PolicyType PolicyType;

    public MaturityData(string policyNumber, DateTime policyStartDate, decimal premiums,
      bool membership, decimal discretionaryBonus, decimal upliftPercentage)
    {
      PolicyNumber = policyNumber;
      PolicyStartDate = policyStartDate;
      Premiums = premiums;
      Membership = membership;
      DiscretionaryBonus = discretionaryBonus;
      UpliftPercentage = upliftPercentage;

      PolicyType = PolicyType.GetPolicyType(PolicyNumber);
    }
  }
}
