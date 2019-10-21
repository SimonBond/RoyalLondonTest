using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalLondonTestApp
{
  public class DataReader<T>
  {
    private Func<Dictionary<string, string>, T> Extractor { get; set; }

    public DataReader(Func<Dictionary<string, string>, T> extractor)
    {
      Extractor = extractor;
    }

    public IEnumerable<T> ReadCsv(string filePath)
    {
      CsvReader csvReader = new CsvReader(',');

      foreach (Dictionary<string, string> dict in csvReader.Read(filePath))
      {
        T item = Extractor(dict);

        yield return item;
      }

      yield break;
    }
  }
}
