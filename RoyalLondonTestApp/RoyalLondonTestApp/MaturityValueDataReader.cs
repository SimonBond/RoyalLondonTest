using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RoyalLondonTestApp
{
  public class MaturityValueDataReader
  {
    public List<MaturityValueData> ReadFile(string filePath)
    {
      System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<MaturityValueData>));

      TextReader reader = new StreamReader(filePath);
      List<MaturityValueData> maturityValueDatas = (List<MaturityValueData>)serializer.Deserialize(reader);

      return maturityValueDatas;
    }
  }
}
