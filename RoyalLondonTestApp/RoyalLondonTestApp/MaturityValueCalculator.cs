using System;

namespace RoyalLondonTestApp
{
  public class MaturityValueCalculator
  {
    /// <summary>
    /// Calulates the Maturity Value. Does not round the result.
    /// </summary>
    /// <param name="premium"></param>
    /// <param name="managementFeePC"></param>
    /// <param name="qualifyingDiscretionaryBonus"></param>
    /// <param name="upliftPC"></param>
    /// <returns>Maturity Value</returns>
    virtual public decimal Calculate(decimal premium, decimal managementFeePC, decimal qualifyingDiscretionaryBonus, decimal upliftPC)
    {
      decimal managementFee = premium * managementFeePC / 100m;
      decimal upliftFactor = 1m + (upliftPC / 100m);
      return ((premium - managementFee) + qualifyingDiscretionaryBonus) * upliftFactor;
    }
  }
}
