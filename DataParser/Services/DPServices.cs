using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataParser.Models;
using DataParser.DAL;
using System.IO;

namespace DataParser.Services
{
    public class DPServices
    {
        public static List<DataLine> LoadData(string filePath)
        {
            var retVal = new List<DataLine>();
            var dataLines = DataLineDAL.GetInput(filePath);
            foreach (var line in dataLines)
            {
                var parseLine = ParseDataLine(line);
                if (parseLine != null)
                {
                    retVal.Add(ParseDataLine(line));
                }
            }
            return retVal;
        }
        public static void SaveOutputFile(string outputFilePath, List<OutputData> outputData)
        {
            DataLineDAL.SaveOutputFile(outputFilePath, outputData);
        }
        public static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
        private static DataLine ParseDataLine(string line)
        {
            
            DataLine dataLine = null;
            line = line.Replace("\"", "").Replace(" ", "");
            //checked to see if this is the header.
            if (!line.Split(',')[0].Contains("GUID"))
            { var items = line.Split(',').ToList();
                dataLine = new DataLine
                {
                    DataGuid = items[(int)DataLine.field.Guid],
                    Val1 = items[(int)DataLine.field.Val1],
                    Val2 = items[(int)DataLine.field.Val2],
                    Val3 = items[(int)DataLine.field.Val3]
                };
            }
           
            return dataLine;
        } 
    }
}
