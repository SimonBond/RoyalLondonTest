using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RoyalLondonTestApp
{
  public class Process
  {
    private MaturityValueCalculator _maturityValueCalculator;
    private DataReader<MaturityData> _maturityDataReader;
    private MaturityValueDataWriter _maturityValueDataWriter;

    public Process(MaturityValueCalculator maturityValueCalculator, DataReader<MaturityData> maturityDataReader, MaturityValueDataWriter maturityValueDataWriter)
    {
      _maturityValueCalculator = maturityValueCalculator;
      _maturityDataReader = maturityDataReader;
      _maturityValueDataWriter = maturityValueDataWriter;
    }

    public void ProcessFile(string csvFilePath)
    {
      FileInfo fileInfo = new FileInfo(csvFilePath);
      if (!fileInfo.Exists)
      {
        throw new FileNotFoundException("File Not Found", csvFilePath);
      }

      // The name of the xml output file has not been specified, so we'll just change the extension
      string xmlFilePath = Path.ChangeExtension(csvFilePath, "xml");

      List<MaturityValueData> maturityValueDatas = new List<MaturityValueData>();

      // Read the entire file and create the whole MaturityValueData list - there's no attempt to batch the output
      foreach(MaturityData md in _maturityDataReader.ReadCsv(csvFilePath))
      {
        MaturityValueData mvd = new MaturityValueData();
        mvd.PolicyNumber = md.PolicyNumber;
        mvd.MaturityValue = _maturityValueCalculator.Calculate(md.Premiums, md.PolicyType.ManagementFeePC, md.QualifyingDiscretionaryBonus, md.UpliftPercentage);

        maturityValueDatas.Add(mvd);
      }

      _maturityValueDataWriter.Write(maturityValueDatas, xmlFilePath);
    }
  }
}
