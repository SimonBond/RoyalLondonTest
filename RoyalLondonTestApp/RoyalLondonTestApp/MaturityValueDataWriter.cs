using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RoyalLondonTestApp
{
  public class MaturityValueDataWriter
  {
    public void Write(List<MaturityValueData> maturityValueDatas, string filePath)
    {
      // The format of the xml file has not been specified, so just serialise the list
      System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<MaturityValueData>));

      TextWriter writer = new StreamWriter(filePath);
      serializer.Serialize(writer, maturityValueDatas);
      writer.Close();
    }
  }
}
