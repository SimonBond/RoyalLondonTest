using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalLondonTestApp
{
  abstract public class PolicyType
  {
    public string Name;
    public decimal ManagementFeePC;

    public PolicyType(string name, decimal managementFeePC)
    {
      Name = name;
      ManagementFeePC = managementFeePC;
    }

    virtual public bool QualifiesForDiscretionayBonus(MaturityData maturityData)
    {
      throw new NotImplementedException();
    }

    static public PolicyType GetPolicyType(string policyNumber)
    {
      switch (policyNumber[0])
      {
        case 'A':
          {
            return new PolicyTypeA();
          }
        case 'B':
          {
            return new PolicyTypeB();
          }
        case 'C':
          {
            return new PolicyTypeC();
          }
        default:
          throw new Exception($"Unrecognised Policy Number {policyNumber}");
      }
    }
  }

  class PolicyTypeA : PolicyType
  {
    // Note - The ManagementFee % is hard coded here
    // As are the rules for qualifying for the Discretionay Bonus.
    public PolicyTypeA() : base("A", 3)
    { }

    override public bool QualifiesForDiscretionayBonus(MaturityData maturityData)
    {
      return maturityData.PolicyStartDate.Year < 1990;
    }
  }

  class PolicyTypeB : PolicyType
  {
    public PolicyTypeB() : base("B", 5)
    { }

    override public bool QualifiesForDiscretionayBonus(MaturityData maturityData)
    {
      return maturityData.Membership;
    }
  }

  class PolicyTypeC : PolicyType
  {
    public PolicyTypeC() : base("C", 7)
    { }

    override public bool QualifiesForDiscretionayBonus(MaturityData maturityData)
    {
      return maturityData.Membership && maturityData.PolicyStartDate.Year >= 1990;
    }
  }
}
