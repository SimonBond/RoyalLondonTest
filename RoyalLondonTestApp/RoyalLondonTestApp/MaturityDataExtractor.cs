using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalLondonTestApp
{
  public static class MaturityDataExtractor
  {
    public static MaturityData Extractor(Dictionary<string, string> dict)
    {
      string policyNumber = dict["policy_number"];
      DateTime policyStartDate = DateTime.Parse(dict["policy_start_date"]);
      decimal premiums = decimal.Parse(dict["premiums"]);
      bool membership = dict["membership"].Equals("Y", StringComparison.InvariantCultureIgnoreCase);
      decimal discretionaryBonus = decimal.Parse(dict["discretionary_bonus"]);
      decimal upliftPercentage = decimal.Parse(dict["uplift_percentage"]);

      MaturityData md = new MaturityData(policyNumber, policyStartDate, premiums, membership, discretionaryBonus, upliftPercentage);

      return md;
    }
  }
}
