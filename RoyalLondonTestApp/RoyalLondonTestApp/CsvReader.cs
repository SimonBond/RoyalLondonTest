using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RoyalLondonTestApp
{
  /// <summary>
  /// A unsophisticated csv file reader.
  /// Assumes the first line has unique column headings
  /// and each row has the same number of fields.
  /// </summary>
  public class CsvReader
  {
    private List<string> _headers;

    private char _delimiter;

    public CsvReader(char delimiter)
    {
      _delimiter = delimiter;
    }

    // Could implement this if order of fields is certain and unchanging
    //public IEnumerable<List<string>> Read(string filePath)
    //{
    //}

    /// <summary>
    /// Enumerates through each line after reading the first line as a header.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>Each line as a Dictionary keyed by the column headings</returns>
    public IEnumerable<Dictionary<string, string>> Read(string filePath)
    {
      // TODO check file exists
      // Checked elsewhere

      // Could use Microsoft.VisualBasic.FileIO.TextFieldParser

      bool firstLine = true;
      using (TextReader textReader = new StreamReader(filePath))
      {
        while (textReader.Peek() > -1)
        {
          if (firstLine)
          {
            // Get the header line
            string line = textReader.ReadLine();
            _headers = Tokenize(line);
            firstLine = false;
          }
          else
          {
            Dictionary<string, string> returnValue = new Dictionary<string, string>();

            string line = textReader.ReadLine();
            List<string> tokenizedStrings = Tokenize(line);

            if (tokenizedStrings.Count != _headers.Count)
            {
              throw new Exception($"Invalid line in file {filePath} {_headers.Count} fields expected {tokenizedStrings.Count} found");
            }

            for (int index = 0; index < _headers.Count; ++index)
            {
              returnValue.Add(_headers[index], tokenizedStrings[index]);
            }
            yield return returnValue;
          }
        }
        yield break;
      }
    }

    private List<string> Tokenize(string line)
    {
      List<string> tokenizedStrings = new List<string>(line.Split(_delimiter));
      return tokenizedStrings;
    }
  }
}
