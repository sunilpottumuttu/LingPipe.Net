using clrsystem = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.aliasi.classify;
using java.io;
using clrio= System.IO;

namespace LingPipeOnDotNetDemos
{
    public class Util
    {

        public static int SCORE = 0;
        public static int GUESSED_CLASS = 1;
        public static int ANNOTATION_OFFSET = 2;
        public static int TEXT_OFFSET = 3;


        public static string GetRequiredFilesDirectory()
        {
            string AssemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return AssemblyPath + @"/../../../RequiredFilesForDemo/";
        }


        public static void consoleInputPrintClassification(BaseClassifier classifier, string input)
        {
            Classification classification = classifier.classify(input);
            clrsystem.Console.WriteLine(classification);
        }

        public static void ConsoleInputBestCategory(BaseClassifier classifier)
        {
            while (true)
            {
                clrsystem.Console.WriteLine("\nType a string to be classified. " + " Emptystring to quit.");
                string data = clrsystem.Console.ReadLine();
                if (data.Equals(""))
                {
                    return;
                }

                Classification classification = classifier.classify(data);
                //clrsystem.Console.WriteLine("Best Category: " + classification.bestCategory());
            }
        }

        public static List<string[]> readCsvRemoveHeader(string inputPath)
        {
            List<string[]> rows = new List<string[]>();
            using (CsvFileReader reader = new CsvFileReader(inputPath))
            {
                CsvRow row = new CsvRow();
                reader.ReadLine(); //skip first row
                while (reader.ReadRow(row))
                {
                    if (row[TEXT_OFFSET] == null || row[TEXT_OFFSET].Equals(""))
                    {
                        continue;
                    }

                    rows.Add(row.ToArray());
                }
            }
            return rows;
        }
        public static List<string[]> readAnnotatedCsvRemoveHeader(string inputPath)
        {
            List<string[]> rows = new List<string[]>();
            using (CsvFileReader reader = new CsvFileReader(inputPath))
            {
                CsvRow row = new CsvRow();
                reader.ReadLine(); //skip first row
                while (reader.ReadRow(row))
                {
                    if (row[ANNOTATION_OFFSET].Equals(""))
                    { continue; }

                    rows.Add(row.ToArray());
                }
            }
            return rows;
        }

        public static string[] getCategories(List<string[]> data)
        {
            //get categories
            HashSet<string> categories = new HashSet<string>();
            foreach (var item in data)
            {
                if (!item[Util.ANNOTATION_OFFSET].Equals(""))
                {
                    string s = item[ANNOTATION_OFFSET];
                    categories.Add(s);
                }
            }
            return categories.ToArray();
        }


        

        

    }
}
