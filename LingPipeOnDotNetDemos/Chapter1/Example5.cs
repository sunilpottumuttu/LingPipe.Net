using com.aliasi.util;
using java.io;
using System;
using clrio = System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.aliasi.classify;
using java.lang;

namespace LingPipeOnDotNetDemos.Chapter1
{
    /// <summary>
    /// Training your own language model classifier
    /// </summary>
    public class Example5
    {
        public void Run()
        {

            string inputPath = Util.GetRequiredFilesDirectory() + "data/disney_e_n.csv";

            List<string[]> annotatedData = new List<string[]>();

            //use csvfilereader class to read the csv files 
            //as it is observed that while reading csv files \ are coming and proper data is not coming
            using (CsvFileReader reader = new CsvFileReader(inputPath))
            {
                CsvRow row = new CsvRow();
                reader.ReadLine(); //skip first row
                while (reader.ReadRow(row))
                {
                    annotatedData.Add(row.ToArray());
                }
            }

            //get categories
            HashSet<string> categories = new HashSet<string>();
            foreach (var item in annotatedData)
            {
                if (!item[Util.ANNOTATION_OFFSET].Equals(""))
                {
                    string s = item[Util.ANNOTATION_OFFSET];
                    categories.Add(s);
                }
            }

            int maxCharNGram = 3;
            DynamicLMClassifier classifier = DynamicLMClassifier.createNGramBoundary(categories.ToArray(), maxCharNGram);

            foreach (var item in annotatedData)
            {
                string truth = item[Util.ANNOTATION_OFFSET];
                string text = item[Util.TEXT_OFFSET];
                Classification classification = new Classification(truth);
                Classified classified = new  Classified(text, classification);
                classifier.handle(classified);
                //classifier.train(truth, text, 1);
            }
            //todo

        }
    }
}
