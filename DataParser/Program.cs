using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataParser.Models;
using DataParser.Services;

namespace DataParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "";
            do
            {
                Console.Write("Enter the file path. ");
                filePath = Console.ReadLine();
            } while (!DPServices.FileExists(filePath));

            List < DataLine > inputData = Services.DPServices.LoadData(filePath);
            var largestSum = inputData.Max(x => (int.Parse(x.Val1) + (int.Parse(x.Val2))));
            
            // There may be more than one row with the Max sum
            var GuidsWithMaxSum = inputData.Where(x => (int.Parse(x.Val1) + int.Parse(x.Val2)) == largestSum);
            
            // Output
                        Console.WriteLine(string.Format("There are  {0} records in the input file", inputData.Count()));

            Console.WriteLine(string.Format("The largest sum of Val1 and Val2 is {0:N0}", largestSum));

            Console.WriteLine();
            Console.WriteLine("The row(s) that contain that sum:");
            foreach(var g in GuidsWithMaxSum)
            {
                Console.WriteLine(g.DataGuid);
            }

            Console.WriteLine();
            var avgLenth = inputData.Average(x => x.Val3.Length);
            Console.WriteLine(string.Format("The average length of Val3 for the entire input file is {0}", avgLenth));
            
            var duplicateGuids = inputData.GroupBy(s => s.DataGuid).SelectMany(grp => grp.Skip(1)).Select(s=>s.DataGuid);

            if (duplicateGuids.Count() > 0)
            {
                Console.WriteLine("The Duplicate Guids are:");
                foreach (var duplicateGuid in duplicateGuids)
                {
                    Console.WriteLine(duplicateGuid);
                }
            }
            Console.WriteLine();
           
            var outputData = inputData.Select(x => new OutputData
            {
                DataGuid = x.DataGuid,
                ValSum = int.Parse(x.Val1) + int.Parse(x.Val2),
                IsDuplicateGuid = duplicateGuids.Contains(x.DataGuid),
                Val3LengthGreaterThanAverage = x.Val3.Length > avgLenth
            }).ToList();

            string outputFilePath = "";
            Console.Write("Enter the Output file path. ");
            outputFilePath = Console.ReadLine();
            Console.WriteLine("Genertating Output File");

            DPServices.SaveOutputFile(outputFilePath, outputData);

            Console.WriteLine("File Generated. Press any key to continue.");
            Console.ReadKey();
        }
    }
}
