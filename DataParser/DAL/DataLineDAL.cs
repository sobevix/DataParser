using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataParser.Models;

namespace DataParser.DAL
{
    public class DataLineDAL
    {

        public static string[] GetInput(string filePath)
        {
            string[] InputDataLines;
            try
            {
                InputDataLines = File.ReadAllLines(filePath, Encoding.UTF8);
            }
            catch (IOException e)
            {
                throw new IOException("Error reading file" + e.Message);
            }

            return InputDataLines;
        }
        public static void SaveOutputFile(string outputFilePath, List<OutputData> outputData)
        {
            try
            {
                StringBuilder sbOutput = new StringBuilder("\"GUID\",\"Sum\",\"Duplicate\",\"Val3 Lenght Greater Than Average\"\n");
                foreach (var outputLine in outputData)
                {
                    string line = "\"" + outputLine.DataGuid + "\",\"" + outputLine.ValSum + "\",\"" + (outputLine.IsDuplicateGuid ? "Y" : "N") + "\",\"" + (outputLine.Val3LengthGreaterThanAverage ? "Y" : "N") + "\"\n";
                    sbOutput.Append(line);
                    File.WriteAllLines(outputFilePath, sbOutput.ToString().Split('\n'));

                }
            }
            catch (IOException e)
            {
                throw new IOException("Could not save output file. " + e.Message);
            }
        }
    }
}
